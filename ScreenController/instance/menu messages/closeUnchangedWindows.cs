closeUnchangedWindows
	"Close any window that doesn't have unaccepted input.  Because of lingering garbage concerns, not available unless you know the secret incantation."

	| clean |

	"ScreenController indicateWindowsWithUnacceptedInput"

	Sensor leftShiftDown ifFalse: [^ self notYetImplemented].

	clean _ ScheduledControllers scheduledControllers select:
		[:contr | contr modelUnchanged].

	clean do:
		[:contr | contr closeAndUnschedule].
	self restoreDisplay