macSerialAndMIDIPortFile

	^ '/* Adjustments for pluginized VM
 *
 * Note: The Mac support files have not yet been fully converted to
 * pluginization. For the time being, it is assumed that they are linked
 * with the VM. When conversion is complete, they will no longer import
 * "sq.h" and they will access all VM functions and variables through
 * the interpreterProxy mechanism.
 */

#include "sq.h"
#include "SerialPlugin.h"
#include "MidiPlugin.h"

/* initialize/shutdown */
int midiInit() { return true; }
int midiShutdown() {}
int serialPortInit() { return true; }
int serialPortShutdown() {
	serialPortClose(0);
	serialPortClose(1);
}

/* helper function for MIDI module */
int sqMIDIParameter(int whichParameter, int modify, int newValue);

int sqMIDIParameterSet(int whichParameter, int newValue) {
	sqMIDIParameter(whichParameter, true, newValue);
}

int sqMIDIParameterGet(int whichParameter) {
	sqMIDIParameter(whichParameter, false, 0);
}
/* End of adjustments for pluginized VM */

#include <CommResources.h>
#include <CRMSerialDevices.h>
#include <Devices.h>
#include <QuickTimeComponents.h>
#include <QuickTimeMusic.h>
#include <Serial.h>
#include <Strings.h>

/*** Constants ***/
#define INPUT_BUF_SIZE 1000
#define FIRST_DRUM_KIT 16385

/*** Imported Variables ***/
extern int successFlag;

/*** Serial Ports ***/
#define MAX_PORTS 4
short inRefNum[MAX_PORTS] = {0, 0, 0, 0};
short outRefNum[MAX_PORTS] = {0, 0, 0, 0};
char inputBuffer[MAX_PORTS][INPUT_BUF_SIZE];

/* Quicktime MIDI note allocator and channels */
NoteAllocator na = nil;
NoteChannel channel[16] = {
	nil, nil, nil, nil, nil, nil, nil, nil, nil, nil, nil, nil, nil, nil, nil, nil};

/* Initial instruments: drums on channel 10, piano on all other channels */
int channelInstrument[16] = {
	1, 1, 1, 1, 1, 1, 1, 1, 1, FIRST_DRUM_KIT, 1, 1, 1, 1, 1, 1};

/* Quicktime MIDI parser state */
enum {idle, want1of2, want2of2, want1of1, sysExclusive};
int state = idle;
int argByte1 = 0;
int argByte2 = 0;
int lastCmdByte = nil;

/* number of argument bytes for each MIDI command */
char argumentBytes[128] = {
	2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
	2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
	2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
	2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
	1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
	1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
	2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
	3, 1, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
};


/*** Private Functions ***/
int portIsOpen(int portNum);
int portNames(int portNum, char *portName, char *inName, char *outName);
int serialPortCount(void);
int setHandshakeOptions(int portNum, int inFlowCtrl, int outFlowCtrl, int xOnChar, int xOffChar);
int setMidiClockRate(int portNum, int interfaceClockRate);

/*** Quicktime MIDI Support Functions ***/
void closeQuicktimeMIDIPort(void);
void openQuicktimeMIDIPort(void);
void performMIDICmd(int cmdByte, int arg1, int arg2);
void processMIDIByte(int aByte);
void startMIDICommand(int cmdByte);

int serialPortCount(void) {
  /* Return the number of serial ports available on this machine */

#if TARGET_API_MAC_CARBON
    return false;
#else
 	CRMRec		commRec;
 	CRMRecPtr	thisRecPtr;
 	int			count = 0;
 
	InitCRM();
 	commRec.crmDeviceType = crmSerialDevice;
 	commRec.crmDeviceID = 0;
	thisRecPtr = (CRMRecPtr) CRMSearch(&commRec);
 	while (thisRecPtr != nil) {
 		count++;
		commRec.crmDeviceID = thisRecPtr->crmDeviceID;
		thisRecPtr = (CRMRecPtr) CRMSearch(&commRec);
    }
    if (count > MAX_PORTS) count = MAX_PORTS;
 	return count;
#endif
 }

int portIsOpen(int portNum) {
	if ((portNum < 0) || (portNum > 1)) return false;
	return outRefNum[portNum] != 0;
}

int portNames(int portNum, char *portName, char *inName, char *outName) {
/* Fill in the user name and input and output port names for the given
   port number. Note that ports are numbered starting with zero. */

#if TARGET_API_MAC_CARBON
    return false;
#else
 	CRMRec			commRec;
 	CRMRecPtr		thisRecPtr;
 	CRMSerialPtr	serialPtr;
 	int				count = 0;
 
 	portName[0] = inName[0] = outName[0] = 0;
	InitCRM();
 	commRec.crmDeviceType = crmSerialDevice;
 	commRec.crmDeviceID = 0;
	thisRecPtr = (CRMRecPtr) CRMSearch(&commRec);
 	while (thisRecPtr != nil) {
 		if (count == portNum) {
			serialPtr = (CRMSerialPtr) thisRecPtr->crmAttributes;
			CopyPascalStringToC((void *) *(serialPtr->name),portName);
			CopyPascalStringToC((void *) *(serialPtr->inputDriverName),inName);
			CopyPascalStringToC((void *) *(serialPtr->outputDriverName),outName);
 		}
 		count++;
		commRec.crmDeviceID = thisRecPtr->crmDeviceID;
		thisRecPtr = (CRMRecPtr) CRMSearch(&commRec);
    }
#endif
 }

int setHandshakeOptions(
  int portNum, int inFlowCtrl, int outFlowCtrl, int xOnChar, int xOffChar) {
/* Set the given port''s handshaking parameters. */
#if TARGET_API_MAC_CARBON
    return false;
#else

	SerShk handshakeOptions;
	int osErr;

	if (!portIsOpen(portNum)) {
		return success(false);
	}

	handshakeOptions.fInX = false;
	handshakeOptions.fDTR = false;
	if (inFlowCtrl == 1) handshakeOptions.fInX = true;  /* XOn/XOff handshaking */
	if (inFlowCtrl == 2) handshakeOptions.fDTR = true;  /* hardware handshaking */

	handshakeOptions.fXOn = false;
	handshakeOptions.fCTS = false;
	if (outFlowCtrl == 1) handshakeOptions.fXOn = true;  /* XOn/XOff handshaking */
	if (outFlowCtrl == 2) handshakeOptions.fCTS = true;  /* hardware handshaking */

	handshakeOptions.xOn  = xOnChar;	/* XOn character */
	handshakeOptions.xOff = xOffChar;	/* XOff character */
	handshakeOptions.errs = 0;			/* clear errors mask bits */
	handshakeOptions.evts = 0;			/* clear event enable mask bits */

	osErr = Control(outRefNum[portNum], 14, &handshakeOptions);
	if (osErr != noErr) {
		success(false);
	}
#endif
}

int setMidiClockRate(int portNum, int interfaceClockRate) {
/* Put the given port into MIDI mode, which uses a clock supplied
   by an external MIDI interface adaptor to determine the baud rate.
   Possible external clock rates: 31.25 KHz, 0.5 MHz, 1 MHz, or 2 MHz. */
#if TARGET_API_MAC_CARBON
    return false;
#else

	char midiParam = 15;  /* dummy value */
	int osErr;

	if (!portIsOpen(portNum)) {
		return success(false);
	}

	if (interfaceClockRate ==   31250) midiParam = 0x00;
	if (interfaceClockRate ==  500000) midiParam = 0x40;
	if (interfaceClockRate == 1000000) midiParam = 0x80;
	if (interfaceClockRate == 2000000) midiParam = 0xC0;
	if (midiParam == 15) {
		return success(false);  /* bad interfaceClockRate */
	}

	osErr = Control(outRefNum[portNum], 15, &midiParam);
	if (osErr != noErr) {
		return success(false);
	}
#endif
}

/*** Serial Port Functions ***/

int serialPortClose(int portNum) {
#if TARGET_API_MAC_CARBON
    return false;
#else
	int osErr;

	if ((portNum < 0) || (portNum > 1)) {
		return success(false); /* bad port number */
	}
	if (!portIsOpen(portNum)) {
		return;  /* already closed */
	}
	osErr = KillIO(outRefNum[portNum]);
	if (osErr != noErr) {
		success(false);
	}
	osErr = CloseDriver(inRefNum[portNum]);
	if (osErr != noErr) {
		success(false);
	}
	osErr = CloseDriver(outRefNum[portNum]);
	if (osErr != noErr) {
		success(false);
	}

	inRefNum[portNum] = 0;
	outRefNum[portNum] = 0;
#endif
}

int serialPortOpen(
  int portNum, int baudRate, int stopBitsType, int parityType, int dataBits,
  int inFlowCtrl, int outFlowCtrl, int xOnChar, int xOffChar) {
/* Open the given serial port using the given settings. The baud rate can be
   any number between about 224 and 57600; the driver will pick a clock
   divisor that will generate the closest available baud rate. */
#if TARGET_API_MAC_CARBON
    return false;
#else

	short int options, baudRateParam;
	char userName[256], inName[256], outName[256];
	int osErr;

	if ((portNum < 0) || (portNum > 1) || portIsOpen(portNum)) {
		return success(false); /* bad port number or port already open */
	}

	options = baud9600;
	switch (stopBitsType) {
	case 0:
		options += stop15;
		break;
	case 1:
		options += stop10;
		break;
	case 2:
		options += stop20;
		break;
	default:
		return success(false);
	}

	switch (parityType) {
	case 0:
		options += noParity;
		break;
	case 1:
		options += oddParity;
		break;
	case 2:
		options += evenParity;
		break;
	default:
		return success(false);
	}

	switch (dataBits) {
	case 5:
		options += data5;
		break;
	case 6:
		options += data6;
		break;
	case 7:
		options += data7;
		break;
	case 8:
		options += data8;
		break;
	default:
		return success(false);
	}

	portNames(portNum, userName, inName, outName);
	CopyCStringToPascal((const char *)outName,(unsigned char *) outName);
	osErr = OpenDriver((unsigned char *)outName, &outRefNum[portNum]);
	if (osErr != noErr) {
		return success(false);
	}
	CopyCStringToPascal((const char *)inName,(unsigned char *)inName);
	osErr = OpenDriver((unsigned char *)inName, &inRefNum[portNum]);
	if (osErr != noErr) {
		CloseDriver(outRefNum[portNum]);
		return success(false);
	}

	/* set the handshaking options */
	setHandshakeOptions(portNum, inFlowCtrl, outFlowCtrl, xOnChar, xOffChar);

	/* install a larger input buffer */
	osErr = SerSetBuf(inRefNum[portNum], &inputBuffer[portNum][0], INPUT_BUF_SIZE);
	if (osErr != noErr) {
		success(false);
	}

	/* set data bits, parity type, and stop bits */
	osErr = SerReset(outRefNum[portNum], options);
	if (osErr != noErr) {
		success(false);
	}

	/* set the baud rate (e.g., the value 9600 gives 9600 baud) */
	baudRateParam = baudRate;
	osErr = Control(outRefNum[portNum], 13, &baudRateParam);
	if (osErr != noErr) {
		success(false);
	}

	if (!successFlag) {
		CloseDriver(inRefNum[portNum]);
		CloseDriver(outRefNum[portNum]);
		inRefNum[portNum] = 0;
		outRefNum[portNum] = 0;
	}
#endif
}

int serialPortReadInto(int portNum, int count, int bufferPtr) {
/* Read up to count bytes from the given serial port into the given byte array.
   Read only up to the number of bytes in the port''s input buffer; if fewer bytes
   than count have been received, do not wait for additional data to arrive.
   Return zero if no data is available. */
#if TARGET_API_MAC_CARBON
    return false;
#else

	long int byteCount;
	int osErr;

	if (!portIsOpen(portNum)) {
		return success(false);
	}

	osErr = SerGetBuf(inRefNum[portNum], &byteCount);  /* bytes available */
	if (osErr != noErr) {
		return success(false);
	}

	if (byteCount > count) byteCount = count;  /* read at most count bytes */
	osErr = FSRead(inRefNum[portNum], &byteCount, (char *) bufferPtr);
	if (osErr != noErr) {
		return success(false);
	}
	return byteCount;
#endif
}

int serialPortWriteFrom(int portNum, int count, int bufferPtr) {
/* Write count bytes from the given byte array to the given serial port''s
   output buffer. Return the number of bytes written. This implementation is
   synchronous: it doesn''t return until the data has been sent. However, other
   implementations may return before transmission is complete. */

	long int byteCount = count;
	int osErr;

	if (!portIsOpen(portNum)) {
		return success(false);
	}

	osErr = FSWrite(outRefNum[portNum], &byteCount, (char *) bufferPtr);
	if (osErr != noErr) {
		return success(false);
	}
	return byteCount;
}

/*** MIDI Parameters (used with sqMIDIParameter function) ***/

#define sqMIDIInstalled				1
/* Read-only. Return 1 if a MIDI driver is installed, 0 if not.
   On OMS-based MIDI drivers, this returns 1 only if the OMS
   system is properly installed and configured. */

#define sqMIDIVersion				2
/* Read-only. Return the integer version number of this MIDI driver.
   The version numbering sequence is relative to a particular driver.
   That is, version 3 of the Macintosh MIDI driver is not necessarily
   related to version 3 of the Win95 MIDI driver. */

#define sqMIDIHasBuffer				3
/* Read-only. Return 1 if this MIDI driver has a time-stamped output
   buffer, 0 otherwise. Such a buffer allows the client to schedule
   MIDI output packets to be sent later. This can allow more precise
   timing, since the driver uses timer interrupts to send the data
   at the right time even if the processor is in the midst of a
   long-running Squeak primitive or is running some other application
   or system task. */

#define sqMIDIHasDurs				4
/* Read-only. Return 1 if this MIDI driver supports an extended
   primitive for note-playing that includes the note duration and
   schedules both the note-on and the note-off messages in the
   driver. Otherwise, return 0. */

#define sqMIDICanSetClock			5
/* Read-only. Return 1 if this MIDI driver�s clock can be set
   via an extended primitive, 0 if not. */

#define sqMIDICanUseSemaphore		6
/* Read-only. Return 1 if this MIDI driver can signal a semaphore
   when MIDI input arrives. Otherwise, return 0. If this driver
   supports controller caching and it is enabled, then incoming
   controller messages will not signal the semaphore. */

#define sqMIDIEchoOn				7
/* Read-write. If this flag is set to a non-zero value, and if
   the driver supports echoing, then incoming MIDI events will
   be echoed immediately. If this driver does not support echoing,
   then queries of this parameter will always return 0 and
   attempts to change its value will do nothing. */

#define sqMIDIUseControllerCache	8
/* Read-write. If this flag is set to a non-zero value, and if
   the driver supports a controller cache, then the driver will
   maintain a cache of the latest value seen for each MIDI controller,
   and control update messages will be filtered out of the incoming
   MIDI stream. An extended MIDI primitive allows the client to
   poll the driver for the current value of each controller. If
   this driver does not support a controller cache, then queries
   of this parameter will always return 0 and attempts to change
   its value will do nothing. */

#define sqMIDIEventsAvailable		9
/* Read-only. Return the number of MIDI packets in the input queue. */

#define sqMIDIFlushDriver			10
/* Write-only. Setting this parameter to any value forces the driver
   to flush its I/0 buffer, discarding all unprocessed data. Reading
   this parameter returns 0. Setting this parameter will do nothing
   if the driver does not support buffer flushing. */

#define sqMIDIClockTicksPerSec		11
/* Read-only. Return the MIDI clock rate in ticks per second. */

#define sqMIDIHasInputClock			12
/* Read-only. Return 1 if this MIDI driver timestamps incoming
   MIDI data with the current value of the MIDI clock, 0 otherwise.
   If the driver does not support such timestamping, then the
   client must read input data frequently and provide its own
   timestamping. */

/*** MIDI Functions ***/

int sqMIDIClosePort(int portNum) {
/* Close the given MIDI port. Do nothing if the port is not open.
   Fail if there is no port of the given number.*/

	int serialPorts;
	
	serialPorts = serialPortCount();
	if (portNum == serialPorts) {
		closeQuicktimeMIDIPort();
		return;
	} else {
		return serialPortClose(portNum);
	}
}

int sqMIDIGetClock(void) {
/* Return the current value of the clock used to schedule MIDI events.
   The MIDI clock is assumed to wrap at or before half the maximum
   positive SmallInteger value. This allows events to be scheduled
   into the future without overflowing into LargePositiveIntegers. 
   This implementation does not support event scheduling, so it
   just returns the value of the Squeak millisecond clock. */

	return ioMicroMSecs();
}

int sqMIDIGetPortCount(void) {
/* Return the number of available MIDI interfaces, including both
   hardware ports and software entities that act like ports. Ports
   are numbered from 0 to N-1, where N is the number returned by this
   primitive. */

	return serialPortCount() + 1;  /* serial ports + QuickTime Synth */
}

int sqMIDIGetPortDirectionality(int portNum) {
/* Return an integer indicating the directionality of the given
   port where: 1 = input, 2 = output, 3 = bidirectional. Fail if
   there is no port of the given number. */

	
	int serialPorts;
	
	serialPorts = serialPortCount();
	if (portNum > serialPorts) return success(false);
	if (portNum == serialPorts) {
		return 2;
	} else {
		return 3;
	}
}

int sqMIDIGetPortName(int portNum, int namePtr, int length) {
/* Copy the name of the given MIDI port into the string at the given
   address. Copy at most length characters, and return the number of
   characters copied. Fail if there is no port of the given number.*/

	char userName[256], inName[256], outName[256];
	int serialPorts, count;
	
	serialPorts = serialPortCount();
	if (portNum > serialPorts) return success(false);

	if (portNum == serialPorts) {
		strcpy(userName, "QuickTime MIDI");
	} else {
		portNames(portNum, userName, inName, outName);
	}

	count = strlen(userName);
	if (count > length) count = length;
	memcpy((void *) namePtr, userName, count);
	return count;
}

int sqMIDIOpenPort(int portNum, int readSemaIndex, int interfaceClockRate) {
/* Open the given port, if possible. If non-zero, readSemaphoreIndex
   specifies the index in the external objects array of a semaphore
   to be signalled when incoming MIDI data is available. Note that
   not all implementations support read semaphores (this one does
   not); see sqMIDICanUseSemaphore. The interfaceClockRate parameter
   specifies the clock speed for an external MIDI interface
   adaptor on platforms that use such adaptors (e.g., Macintosh).
   Fail if there is no port of the given number.*/

	int serialPorts;
	
	serialPorts = serialPortCount();
	if (portNum > serialPorts) return success(false);

	if (portNum == serialPorts) {
		openQuicktimeMIDIPort();
		return;
	}

	serialPortOpen(portNum, 9600, 1, 0, 8, 0, 0, 0, 0);
	if (successFlag) {
		setMidiClockRate(portNum, interfaceClockRate);
		if (!successFlag) {
			serialPortClose(portNum);
		}
	}
}

int sqMIDIParameter(int whichParameter, int modify, int newValue) {
/* Read or write the given MIDI driver parameter. If modify is 0,
   then newValue is ignored and the current value of the specified
   parameter is returned. If modify is non-zero, then the specified
   parameter is set to newValue. Note that many MIDI driver parameters
   are read-only; attempting to set one of these parameters fails.
   For boolean parameters, true = 1, false = 0. */

	if (modify == 0) {
		switch(whichParameter) {
		case sqMIDIInstalled:
			return 1;
			break;
		case sqMIDIVersion:
			return 100;
			break;
		case sqMIDIHasBuffer:
		case sqMIDIHasDurs:
		case sqMIDICanSetClock:
		case sqMIDICanUseSemaphore:
		case sqMIDIEchoOn:
		case sqMIDIUseControllerCache:
			return 0;
			break;
		case sqMIDIEventsAvailable:
			return 1;  /* pretend that events are always available */
			break;
		case sqMIDIFlushDriver:
			return 0;
			break;
		case sqMIDIClockTicksPerSec:
			return 1000;
			break;
		case sqMIDIHasInputClock:
			return 0;
			break;
		default:
			return success(false);
		}
	} else {
		switch(whichParameter) {
		case sqMIDIInstalled:
		case sqMIDIVersion:
		case sqMIDIHasBuffer:
		case sqMIDIHasDurs:
		case sqMIDICanSetClock:
		case sqMIDICanUseSemaphore:
			return success(false);
			break;
		case sqMIDIEchoOn:
			/* noop; echoing not supported */
			break;
		case sqMIDIUseControllerCache:
			/* noop; controller cache not supported */
			break;
		case sqMIDIEventsAvailable:
			return success(false);
			break;
		case sqMIDIFlushDriver:
			/* noop; buffer flushing not supported */
			break;
		case sqMIDIClockTicksPerSec:
			return success(false);
			break;
		default:
			return success(false);
		}
	}
}

int sqMIDIPortReadInto(int portNum, int count, int bufferPtr) {
/* bufferPtr is the address of the first byte of a Smalltalk
   ByteArray of the given length. Copy up to (length - 4) bytes
   of incoming MIDI data into that buffer, preceded by a 4-byte
   timestamp in the units of the MIDI clock, most significant byte
   first. Implementations that do not support timestamping of
   incoming data as it arrives (see sqMIDIHasInputClock) simply
   set the timestamp to the value of the MIDI clock when this
   function is called. Return the total number of bytes read,
   including the timestamp bytes. Return zero if no data is
   available. Fail if the buffer is shorter than five bytes,
   since there must be enough room for the timestamp plus at
   least one data byte. */

	int bytesRead;

	if (count < 5) return success(false);
	bytesRead = serialPortReadInto(portNum, count - 4, bufferPtr + 4);
	if (bytesRead == 0) return 0;
	*((int *) bufferPtr) = sqMIDIGetClock();  /* set timestamp */
	return bytesRead + 4;
}

int sqMIDIPortWriteFromAt(int portNum, int count, int bufferPtr, int time) {
/* bufferPtr is the address of the first byte of a Smalltalk
   ByteArray of the given length. Send its contents to the given
   port when the MIDI clock reaches the given time. If time equals
   zero, then send the data immediately. Implementations that do
   not support a timestamped output queue, such as this one, always
   send the data immediately; see sqMIDIHasBuffer. */

	int serialPorts, i;
	unsigned char *bytePtr;
	
	serialPorts = serialPortCount();
	if (portNum > serialPorts) return success(false);

	if (portNum == serialPorts) {
		if (!na) return success(false);  /* QuickTime port not open */
		bytePtr = (unsigned char *) bufferPtr;
		for (i = 0; i < count; i++) {
			processMIDIByte(*bytePtr++);
		}
		return count;
	}
	return serialPortWriteFrom(portNum, count, bufferPtr);
}

/*** Quicktime MIDI Support Functions ***/

void closeQuicktimeMIDIPort(void) {
	int i;

	if (!na) return;
	for (i = 0; i < 16; i++) {
		/* dispose of note channels */
		if (channel[i]) NADisposeNoteChannel(na, channel[i]);
		channel[i] = nil;
	}
	CloseComponent(na);  /* close note allocator */
}

void openQuicktimeMIDIPort(void) {
	ComponentResult err;
	NoteRequest nr;
	NoteChannel nc;
	int i;

	closeQuicktimeMIDIPort();
	na = OpenDefaultComponent(''nota'', 0);
	if (!na) return;

	for (i = 0; i < 16; i++) {
		nr.info.polyphony = 11;					/* max simultaneous tones */
		nr.info.typicalPolyphony = 0x00010000;	/* typical simultaneous tones */
		NAStuffToneDescription(na, 1, &nr.tone);
		err = NANewNoteChannel(na, &nr, &nc);
		if (err || !nc) {
			closeQuicktimeMIDIPort();
			return;
		}
		NAResetNoteChannel(na, nc);
		NASetInstrumentNumber(na, nc, channelInstrument[i]);
		channel[i] = nc;
	}
	state = idle;
	argByte1 = 0;
	argByte2 = 0;
	lastCmdByte = nil;
	return;
}

void performMIDICmd(int cmdByte, int arg1, int arg2) {
	/* Perform the given MIDI command with the given arguments. */

	int ch, cmd, val, instrument, bend;

	ch = cmdByte & 0x0F;
	cmd = cmdByte & 0xF0;
	if (cmd == 128) {  /* note off */
		NAPlayNote(na, channel[ch], arg1, 0);
	}
	if (cmd == 144) {  /* note on */
		NAPlayNote(na, channel[ch], arg1, arg2);
	}
	if (cmd == 176) {  /* control change */
		if ((arg1 >= 32) && (arg1 <= 63)) {
			val = arg2 << 1;  /* LSB of controllers 0-31 */
		} else {
			val = arg2 << 8;  /* scale MSB to QT controller range */
		}
		NASetController(na, channel[ch], arg1, val);
	}
	if (cmd == 192) {  /* program change */
		if (ch == 9) {
			instrument = FIRST_DRUM_KIT + arg1;  /* if channel 10, select a drum set */
		} else {
			instrument = arg1 + 1;
		}
		NASetInstrumentNumber(na, channel[ch], instrument);
		channelInstrument[ch] = instrument;
	}
	if (cmd == 224) {  /* pitch bend */
		bend = ((arg2 << 7) + arg1) - (64 << 7);
		bend = bend / 32;  /* default sensitivity = +/- 2 semitones */
		NASetController(na, channel[ch], kControllerPitchBend, bend);
	}
}

void processMIDIByte(int aByte) {
	/* Process the given incoming MIDI byte and perform any completed commands. */

	if (aByte > 247) return;  /* skip all real-time messages */

	switch (state) {
	case idle:
		if (aByte >= 128) {
			/* start a new command using the action table */
			startMIDICommand(aByte);
		} else {
			/* data byte arrived in idle state: use running status if possible */
			if (lastCmdByte == nil) {
				return;  /* last command byte is not defined; just skip this byte */
			} else {
				/* process this data as if it had the last command byte in front of it */
				startMIDICommand(lastCmdByte);
				/* the previous line put us into a new state; we now do a recursive
			   	   call to process the data byte in this new state. */
				processMIDIByte(aByte);
				return;
			}
		}
		break;
	case want1of2:
		argByte1 = aByte;
		state = want2of2;
		break;
	case want2of2:
		argByte2 = aByte;
		performMIDICmd(lastCmdByte, argByte1, argByte2);
		state = idle;
		break;
	case want1of1:
		argByte1 = aByte;
		performMIDICmd(lastCmdByte, argByte1, 0);
		state = idle;
		break;
	case sysExclusive:
		if (aByte < 128) {
			/* skip a system exclusive data byte */
		} else {
			if (aByte < 248) {
				/* a system exclusive message can be terminated by any non-real-time command byte */
				state = idle;
				if (aByte != 247) {
					processMIDIByte(aByte);	/* if not endSysExclusive, byte is the start the next command */
				}
			}
		}
		break;
	}
}

void startMIDICommand(int cmdByte) {
	/* Start processing a MIDI message beginning with the given command byte. */

	int argCount;

	argCount = argumentBytes[cmdByte - 128];
	switch (argCount) {
	case 0:						/* start a zero argument command (e.g., a real-time message) */
		/* Stay in the current state and don''t change active status.
		   Real-time messages may arrive between data bytes without disruption. */
		performMIDICmd(cmdByte, 0, 0);
		break;
	case 1:						/* start a one argument command */
		lastCmdByte = cmdByte;
		state = want1of1;
		break;
	case 2:						/* start a two argument command */
		lastCmdByte = cmdByte;
		state = want1of2;
		break;
	case 3:						/* start a variable length ''system exclusive'' command */
		/* a system exclusive command clears running status */
		lastCmdByte = nil;
		state = sysExclusive;
		break;
	}
}
'