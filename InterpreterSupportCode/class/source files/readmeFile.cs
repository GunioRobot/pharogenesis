readmeFile

	^ 'Building the Squeak Virtual Machine

The Macintosh virtual machine is built using the following source files:

	sq.h				-- shared definitions included in all .c files
	sqConfig.h			-- platform configuration settings
	sqMachDep.h		-- machine dependent macros to support threaded code
	sqPlatformSpecific.h -- platform specific macros and definitions
	sqVirtualMachine.h	-- support for dynamic primitives
	sqADPCMPrims.c		-- ADCPM sound compression primitives
	sqFilePrims.c		-- file primitives
	sqMacAsyncFilePrims.c -- Mac asynchronous file I/O
	sqMacDirectory.c	-- Mac directory enumerations
	sqMacJoystickAndTablet.c -- Mac support for Wacom tablets and Gravis
MouseStickII joystick
	sqMacNetwork.c		-- Mac networking primitives
	sqMacSerialAndMIDIPort.c -- Mac serial and MIDI port primitives
	sqMacSound.c		-- Mac audio output primitives
	sqMacWindow.c		-- Mac window and event handling; main program
	sqMiscPrims.c		-- miscellaneous automatically generated primitives
	sqNamedPrims.c		-- support for named primitives
	sqSoundPrims.c		-- automatically generated sound synthesis primitives
	sqOldSoundPrims.c	-- old versions of sound primitives for backward
compatibility
	sqVirtualMachine.c	-- support for dynamic primitives
	interp.c				-- automatically generated code for the virtual
machine

In addition to these files, a number of .h and .c files are generated when Squeak
generates a new interpreter. The exact set of files depends on which sets of
primitives are included. In general, all the files created by this process should
be visible to the CW project and all the generated .c files should be added to
the CW project. Don''t worry--the linker will tell you if you forget something.

The platform specific files are sqMacXXX.c, totaling about 2000 lines of code
when this document was originally written. All other code is written to standard
ANSI libraries and should port easily to other C environments.

The file sqMacMinimal.c can be used a porting guide. This ~1100 line file stubs
out all non-essential support functions and, together with sqFilePrims.c, allows
one to build a functioning virtual machine that only lacks non-essential I/O
functions (including support for file directory enumeration, which is not really
essential!). The small size of this file demonstrates how little code is really
needed to get Squeak running on a new platform.

Thanks to Ian Piumarta, the C header files are identical across all the major
Squeak platforms.

The code assumes that C ints and pointers are 4 bytes and double floats are 8
bytes; these assumptions are checked at start up time. Float objects in the image
are stored in the IEEE standard byte ordering for double-precision floats on all
platforms; macros in sq.h can be defined to swap bytes into and out of the
platform native float format if necessary. (To ensure proper word alignment, one
typically has to copy a Squeak Float object into a C "double" variable before
operating on it; byte swapping can be done while doing this copy for little or no
additional cost.)

The files interp.c, sqSoundPrims.c, and sqMiscPrims.c are generated
automatically, so changes to these files will be lost when they are next
generated. It is fine to make ephemeral changes to these file for the purpose of
debugging or statistics gathering. To generate the interpreter, see the
"translation" category in Interpreter class. To generate sqSoundPrims.c, see the
class method "cCodeForSoundPrimitives" in AbstractSound.

The current VM was compiled with Metrowerks CodeWarrior 11. Earlier, I used
Semantec Think C 6.0, but discovered a few bugs in their libraries having to do
with 8-byte versus 4-byte integers. These bugs have probably been fixed by now.

This code has also been compiled under the MPW "Mr. C" Macintosh compiler by
Hans-Martin Mosner (hmm@heeg.de) with only one minor change: you will need to
create an empty "MacHeaders.h" file. You may get some harmless compiler warnings
and, for peak performance, the method that patches the dispatch loop must also be
changed. Hans-Martin says: "The whole VM seems to be marginally slower than the
delivered VM, but it is significantly smaller."

Note that Jitter 3 (Squeak V3.x) has migrated to Gnu GCC, and MPW. As of late fall 2000
there is no 68K version, but the macintosh specific source is the same as for CW.

The virtual machine uses the following libraries:

	Libraries for 68K Project:
		dnr.c
		InterfaceLib
		MathLibCFM68K (4i/8d).Lib
		MSL C.CFM68K Far(4i/8d).Lib
		MWCFM68KRuntime.Lib
		Profiler68kCFM.lib
		QuickTimeLib
		
		//Optional only to build OT version of 68K do not include in regular
build
		OpenTpt68kATalkLib
		OpenTpt68kClientLib
		OpenTpt68kInetLib
		OpenTpt68kUtilLib

	Libraries for PowerPC Project:
		InterfaceLib
		MathLib
		MSL C.PPC.Lib
		MWCRuntime.Lib
		profilerPPC.lib
		QuickTimeLib
		OpenTptInetPPC.o
		OpenTptInternetLib
		OpenTransportExtnPPC.o
		OpenTransportLib

The 68K Mac networking code also requires three files from Apple''s MacTCP
developer''s kit:

	MacTCP.h
	AddressXlation.h
	dnr.c

For convenience, these files are included.

The shipping 68K version of Squeak uses the older MacTCP interface. You can alter
the sqMacNetwork.c file and compile your own 68K verion of Squeak that uses the
new Open Transport version, but the availability of the 68K version of Open
Transport V1.3 is limited to 68040 machines that run system 8.1. You can run this
configuration on a 68030 using system 7.5.x but Apple does not support that
configuration.

To build a fat binary, build the 68K version first, and make sure that the file
"Squeak VM 68K" is included in the PowerPC project. Then build the PowerPC
version. CodeWarrior will include the 68K interpreter in the resource fork of the
output file, resulting in an interpreter that runs on either 68K or PowerPC Macs.
(JMM) Note I had some problems building the FAT application with CW11 I had to
copy the SqueakApp.rsrc items over to the application after it was built, these
resources aren''t copied from the 68K application like the documentation says they
should.

To get an additional speedup, the object code for the bytecode dispatch loop of
the PPC version can be patched using the method "patchInterp:" in Interpreter
class.

Note: In order to support dynamically loaded primitives, we have switched to
using Code Fragement Manager model for the 68K VM. This has several
ramifications:

  1. You now need to use the CFM versions of the library files. The 68K project
file has been updated accordingly.
  2. You cannot run the 68K VM under the emulator on the PowerPC (Apple doesn''t
support CFM apps under the 68K emulator).
  3. You need to be sure that version 4.0 or later of "CFM-68K Runtime Enabler"
is in the Extensions folder of the system folder on your 68K Mac. *** Warning:
Older versions of "CFM-68K Runtime Enabler" had bugs that will probably prevent
Squeak from even starting! ***.

Carbon

We do not include a Carbon ready project at this time. Much of the work to make a
Carbon application is done, however we are still missing versions of the sound
plugin and the serialMidi plugin which are Carbon compliant. 

Building Named Primitive Plugins

I''ve included a pair of sample projects for building Squeak primitive plugins. As
usual, you must build the 68K version first, then the FAT one. If you don''t need
a FAT version, you can remove the 68K project from the PPC one.

Pluginized VM

Squeak 2.8 introduces the "pluginized VM". In the interest of getting a Mac
version of the 2.8 out as quickly and with as little chance of introducing bugs
as possible, I''ve made the bare minimal changes to the Mac support files. For
this reason, all the Mac primitives that were previously linked into the VM must
still be built into the VM as "internal" primitives. That is because many of them
still access a few VM functions and variables directly, rather than calling
through the interpreter proxy, which they must in order to run in an external
plugin. One can still override these builtin primitives with an external plugin
and, of course, newly built plugins can be created as external or internal
plugins. When the dust settles, it will be easy to make the final few changes
required.

Building Squeak as a Browser Plugin

I''ve included an archive containing a CW project file and various supporting
files for building the Squeak VM as plugin for Netscape or Internet Explorer on
the Mac. The plugin works with versions 4.0 or later of either browser. However,
the primitives that can be used to ask the browser to fetch a URL do not work in
versions of IE earlier than 5.0. There are also two resource files the contain
the strings needed to tell the browser about the plugin--its name, version, and
the mime and file extensions it recognizes.

To build this, you will need a copy of the Netscape Plugin SDK, available for
free at their web site. The required support files are:
	jri.h
	jritypes.h
	jri_md.h
	npapi.h
	npmac.cpp
	npupp.h

The installation and use of Squeak as a browser plugin is somewhat beyond the
scope of this readme file. The basic idea is that the Squeak image started by the
browser lives in a pre-defined directory ("System
Folder:Preferences:Squeak:Internet" by default) with predefined name (e.g.,
"squeak.image"). The browser plugin can only read and write files within the
Internet directory and directories contained within it. This is called Squeak
file system "sand box". The browser captures most of the command key combination,
so you have to use the menus rather than your favorite Squeak command key
shortcuts. {Note that using the full screen option allows you to again use the
command key combinations and has better performance characteristics.} The browser
also captures cmd-., so the interrupt key when running under the browser is
control-C. The most flexible way to invoke Squeak is through the HTML "EMBED"
command. This allows arbitrary arguments to be made available to Squeak. The
"memory" EMBED tag can be used to tell Squeak how much memory is required by a
given Squeaklet.

To build a browser plugin VM, do the following:

  1. translate a browser plugin version of the interpreter (using
Interpreter>translateForBrowserPlugin:).
  2. edit the file sqMacWindow.c and uncomment the #define of "PLUGIN"
  3. edit the file platform.exports and uncomment the #define of "PLUGIN"
  4. build the plugin using the supplied browser plugin project

If you build your own project file, note that IE requires that the main entry
point be "main" rather than CW''s usual "__start". (Netscape doesn''t care, so it
took me a long time to figure out why it wasn''t working under IE!) The supplied
project produces a PPC-only plugin.

	-- John Maloney, May 25, 2000,
	-- Changes John M McIntosh Aug 2, 2000, Dec 1,2000
'