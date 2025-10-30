/*******************************************************************************
 *
 * Minimal PicoScope 5000 Series (ps5000a) Example Program
 *
 * Description:
 *   This minimal console program demonstrates how to use the PicoScope 5000 Series
 *   (ps5000a) driver API to perform a basic block data acquisition and save the
 *   results to a text file.
 *
 *   Supported PicoScope models:
 *     PicoScope 5242A/B/D & 5442A/B/D
 *     PicoScope 5243A/B/D & 5443A/B/D
 *     PicoScope 5244A/B/D & 5444A/B/D
 *
 *   Usage:
 *     - Automatically opens the first available PicoScope device
 *     - Configures channels and voltage range
 *     - Collects a block of samples
 *     - Saves the data to "block.txt"
 *
 * Copyright (C) 2013-2018 Pico Technology Ltd. See LICENSE file for terms.
 *
 ******************************************************************************/

#include <stdio.h>

/* Headers for Linux */
#include <unistd.h>
#include <libps5000a/ps5000aApi.h>
#define Sleep(a) usleep(1000*a)
#define scanf_s scanf
#define memcpy_s(a,b,c,d) memcpy(a,c,d)
typedef enum enBOOL{FALSE,TRUE} BOOL;
int32_t _getch() { return getchar(); }
int32_t _kbhit() { return 0; }
int32_t fopen_s(FILE ** a, const char * b, const char * c) { FILE * fp = fopen(b,c); *a = fp; return (fp>0)?0:-1; }

#define BUFFER_SIZE 1024

typedef struct {
	int16_t handle;
	int16_t maxADCValue;
	int16_t channelCount;
	struct {
		int16_t DCcoupled;
		int16_t range;
		int16_t enabled;
		float analogueOffset;
	} channelSettings[4];
} UNIT;

uint16_t inputRanges[] = {10,20,50,100,200,500,1000,2000,5000,10000,20000,50000};
int8_t blockFile[20] = "block.txt";
uint32_t timebase = 8;
BOOL scaleVoltages = TRUE;

int32_t adc_to_mv(int32_t raw, int32_t rangeIndex, UNIT * unit) {
	return (raw * inputRanges[rangeIndex]) / unit->maxADCValue;
}

/*
 * setDefaults
 * Configure channels with current settings.
 */
void setDefaults(UNIT * unit) {
	for (int i = 0; i < unit->channelCount; i++) {
		ps5000aSetChannel(unit->handle, (PS5000A_CHANNEL)i,
			unit->channelSettings[i].enabled,
			unit->channelSettings[i].DCcoupled,
			unit->channelSettings[i].range,
			unit->channelSettings[i].analogueOffset);
	}
}

/*
 * blockDataHandler
 * Acquire a block of data and save to file.
 */
void blockDataHandler(UNIT * unit) {
	int16_t * buffers[8];
	int32_t sampleCount = BUFFER_SIZE;
	PS5000A_RATIO_MODE ratioMode = PS5000A_RATIO_MODE_NONE;
	FILE * fp = NULL;

	for (int i = 0; i < unit->channelCount; i++) {
		if (unit->channelSettings[i].enabled) {
			buffers[i * 2] = (int16_t*) calloc(sampleCount, sizeof(int16_t));
			buffers[i * 2 + 1] = (int16_t*) calloc(sampleCount, sizeof(int16_t));
			ps5000aSetDataBuffers(unit->handle, (PS5000A_CHANNEL)i, buffers[i * 2], buffers[i * 2 + 1], sampleCount, 0, ratioMode);
		}
	}

	int32_t timeInterval, maxSamples;
	ps5000aGetTimebase(unit->handle, timebase, sampleCount, &timeInterval, &maxSamples, 0);

	ps5000aRunBlock(unit->handle, 0, sampleCount, timebase, &timeInterval, 0, NULL, NULL);
	Sleep(100);

	ps5000aGetValues(unit->handle, 0, (uint32_t*)&sampleCount, 1, ratioMode, 0, NULL);

	fopen_s(&fp, blockFile, "w");
	if (fp != NULL) {
		fprintf(fp,"Block Data log\n\n");
		for (int i = 0; i < sampleCount; i++) {
			for (int j = 0; j < unit->channelCount; j++) {
				if (unit->channelSettings[j].enabled) {
					fprintf(fp, "%d ", scaleVoltages ?
						adc_to_mv(buffers[j * 2][i], unit->channelSettings[j].range, unit) :
						buffers[j * 2][i]);
				}
			}
			fprintf(fp, "\n");
		}
		fclose(fp);
	}

	ps5000aStop(unit->handle);

	for (int i = 0; i < unit->channelCount; i++) {
		if (unit->channelSettings[i].enabled) {
			free(buffers[i * 2]);
			free(buffers[i * 2 + 1]);
		}
	}
}

/*
 * main
 * Entry point: open device, acquire block data, save to file, close device.
 */
int32_t main(void) {
	UNIT unit = {0};
	PICO_STATUS status;
	unit.channelCount = 2;
	for (int i = 0; i < unit.channelCount; i++) {
		unit.channelSettings[i].enabled = TRUE;
		unit.channelSettings[i].DCcoupled = TRUE;
		unit.channelSettings[i].range = 6; // 1000mV
		unit.channelSettings[i].analogueOffset = 0.0f;
	}
	status = ps5000aOpenUnit(&unit.handle, NULL, PS5000A_DR_8BIT);
	if (status != PICO_OK) {
		printf("Unable to open device, error code: 0x%08x\n", (uint32_t)status);
		return 1;
	}
	ps5000aMaximumValue(unit.handle, &unit.maxADCValue);
	setDefaults(&unit);
	printf("Collecting block data...\n");
	blockDataHandler(&unit);
	ps5000aCloseUnit(unit.handle);
	printf("Done. Data saved to %s\n", blockFile);
	return 0;
}