readmeFile

	^ 'Building the Squeak Virtual Machine

The virtual machine is built from three header and nine source files:

	sq.h				-- shared definitions included in all .c files
	sqConfig.h			-- platform configuration settings
	sqMachDep.h		-- machine dependent macros to support threaded code
	sqFilePrims.c		-- file primitives
	sqMacDirectory.c	-- Mac directory enumerations
	sqMacJoystick.c		-- primitives to support Gravis MouseStickII joystick
	sqMacNetwork.c		-- Mac networking primitives
	sqMacSound.c		-- Mac audio output primitives
	sqMacWindow.c		-- Mac window and event handling; main program
	sqSoundPrims.c		-- automatically generated sound synthesis primitives
	sqOldSoundPrims.c	-- old versions of sound primitives for backward compatibility
	interpreter.c		-- automatically generated code for the virtual machine

The platform specific files are sqMacWindow.c, sqMacDirectory.c, sqMacJoystick.c, sqMacNetwork.c, and sqMacSound.c, totaling about 1800 lines of code when this document was written. All other code is written to standard ANSI libraries and should port easily to other C environments. When doing the initial port to a new system, the functions in sqMacJoystick.c, sqMacNetwork.c, and sqMacSound.c can be replaced by stub functions that do nothing. Thanks to Ian Piumarta, the C header files are identical on the Macintosh and all Unix platforms.

The code assumes that C ints and pointers are 4 bytes and double floats are 8 bytes; these assumptions are checked at start up time. Floats are always stored in PowerPC byte order (which I believe is the same as the IEEE standard byte ordering for double-precision floats); macros in sq.h can be defined to swap bytes into and out of the platform native float format if necessary.

The files interpreter.c and sqSoundPrims.c are generated automatically, so changes to these files will be lost when they are next generated. It is fine to make ephemeral changes to these file for the purpose of debugging or statistics gathering. To generate the interpreter, see the "translation" category in Interpreter class. To generate sqSoundPrims.c, see the class method "cCodeForSoundPrimitives" in AbstractSound.

The current VM was compiled with Metrowerks CodeWarrier 8. Earlier, I used Semantec Think C 6.0, but discovered a few bugs in their libraries having to do with 8-byte versus 4-byte integers. These bugs could probably be worked around if one really wanted to use that environment.

This code has also been compiled under the MPW "Mr. C" Macintosh compiler by Hans-Martin Mosner (hmm@heeg.de) with only one minor change: you will need to create an empty "MacHeaders.h" file. You may get some harmless compiler warnings and, for peak performance, the method that patches the dispatch loop must also be changed. Hans-Martin says: "The whole VM seems to be marginally slower than the delivered VM, but it
is significantly smaller."

The virtual machine uses the following libraries:

	Libraries for 68K Project:
		MathLib68K (4i/8d).Lib
		MacOS.lib
		profiler68k(Small).lib
		SIOUX.68K.Lib
		ANSI (4i/8d) C.68K.lib

	Libraries for PowerPC Project:
		ANSI C.PPC.Lib
		SIOUX.PPC.Lib
		InterfaceLib
		profilerPPC.lib
		MathLib
		MWCRuntime.Lib

The Mac networking code also requires three files from Apple''s MacTCP developer''s kit:

	MacTCP.h
	AddressXlation.h
	dnr.c

For convenience, these files are included.

To build a fat binary, build the 68K version first, and make sure that the file "Squeak VM 68K" is included in the PowerPC project. Then build the PowerPC version. CodeWarrier will include the 68K interpreter in the resource fork of the output file, resulting in an interpreter that runs on either 68K or PowerPC Macs. To get an additional speedup, the object code for the bytecode dispatch loop of the PPC version can be patched using the method "patchInterp:" in Interpreter class.

	-- John Maloney, January 6, 1998
'.
