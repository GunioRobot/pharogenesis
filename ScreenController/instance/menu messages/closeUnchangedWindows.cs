closeUnchangedWindows
	"Close any window that doesn't have unaccepted input."

	| clean |
	(SelectionMenu confirm:
'Do you really want to close all windows
except those with unaccepted edits?')
		ifFalse: [^ self].

	clean := ScheduledControllers scheduledControllers select:
		[:c | c model canDiscardEdits and: [(c isKindOf: ScreenController) not]].
	clean do: [:c | c closeAndUnscheduleNoTerminate].
	self restoreDisplay.
