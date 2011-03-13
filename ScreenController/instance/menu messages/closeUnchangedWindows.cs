closeUnchangedWindows
	"Close any window that doesn't have unaccepted input.  1/12/97 sw."

	| oneModel clean |

	"ScreenController indicateWindowsWithUnacceptedInput"

	true ifTrue: [^ self notYetImplemented].
	self flag: #noteToDan.
	"Dan -- I tried a couple of things in an attempt to find a wholesale way to close all windows that didn't have unsubmitted changes them -- the idea is that sometimes one gets a screen full of dozens of windows from some furious investigation, and wants just to see the last of most of them.  The code below appeared to do the right thing except that in the end the old windows stayed around as garbage, and I dropped this effort before figuring out what I'm doing wrong.  2/5/96 sw"

	clean _ ScheduledControllers scheduledControllers select:
		[:contr | contr modelUnchanged].

	clean do:
		[:contr | contr closeAndUnschedule].
	self restoreDisplay