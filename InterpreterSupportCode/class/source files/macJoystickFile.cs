macJoystickFile

	^ '#include <DeskBus.h>
#include "sq.h"

#define MOUSESTICK_SIGNATURE 0x4A656666
#define MAX_STICKS 4

typedef struct {
	short			rawX;				/* absolute stick position */
	short			rawY;
	unsigned char	buttons;
	char			private1;
	short			cursorX;			/* cursor position */
	short			cursorY;
	char			oldStickType;
	char			private2;
	char			stickOn;			/* true if stick is connected */
	char			private3;
	char			stickControlsCursor;
	char			applicationAware;	/* settings change with application changes */
	char			private4[152];
} MouseStickRec;

typedef struct {
	long			signature;
	char			private1[18];
	short			stickCount;
	char			private2[22];
	MouseStickRec	stick[MAX_STICKS];
} MouseStickSetRec, *MouseStickSetPtr;

/*** Variables ***/
MouseStickSetPtr joySticks = nil;  /* pointer to a joystick set or nil */

int joystickInit(void) {
	/* If a joystick is plugged in and its control panel is installed,
	   initialize the global pointer ''joySticks'' to the joystick set
	   data structure. Otherwise, set it to nil.
	*/

	ADBDataBlock adbGetInfo;
	MouseStickSetPtr sticks;
	int count, i;

	joySticks = nil;  /* set to nil in case we don''t find any joysticks */

	count = CountADBs();
	for (i = 1; i <= count; i++) {
		GetADBInfo(&adbGetInfo, GetIndADB(&adbGetInfo, i));
		sticks = (MouseStickSetPtr) adbGetInfo.dbDataAreaAddr;
		if ((sticks != nil) && (sticks->signature == MOUSESTICK_SIGNATURE)) {
			joySticks = sticks;
			return;
		}
	}
}

int joystickRead(int stickIndex) {
	/* Return input word for the joystick with the given index (in range [1..2]
	   on the Macintosh; other platforms may vary). This word is encoded as follows:

		<onFlag (1 bit)><buttonFlags (5 bits)><x-value (11 bits)><y-value (11 bits)>

	   The highest four bits of the input word are zero. If the onFlag bit is zero,
	   there is no joystick at the given index. This may be because no joystick
	   is connected or the joystick control panel is not installed. In such,
	   cases, the entire word will be zero. A maximum of two joysticks are supported
	   by Gravis''s current version of the control panel. The x and y values are
	   11-bit signed values in the range [-1024..1023] representing the raw (unencoded)
	   joystick position. The MouseStick II only uses the approximate range [-650..650].
	   The range and center values of poorly adjusted joysticks may vary; the client
	   software should provide a way to adjust the center and scaling to correct.
	*/

	MouseStickRec stickData;
	int buttons, xBits, yBits;

	if ((joySticks == nil) || (stickIndex < 1) || (stickIndex > 2) ||
		(stickIndex > joySticks->stickCount)) {
			return 0;  /* no joystick at the given index */
	}
	stickData = joySticks->stick[stickIndex - 1];  /* 1-based index */
	buttons = ~stickData.buttons & 0x1F;
	xBits = (0x400 + stickData.rawX) & 0x7FF;
	yBits = (0x400 + stickData.rawY) & 0x7FF;
	return (1 << 27) | (buttons << 22) | (yBits << 11) | xBits;
}
'