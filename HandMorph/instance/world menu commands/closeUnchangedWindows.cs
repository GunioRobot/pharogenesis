closeUnchangedWindows
	"Present a menu of window titles for all windows with changes,
	and activate the one that gets chosen."

	(SelectionMenu confirm:
'Do you really want to close all windows
except those with unaccepted edits?')
		ifFalse: [^ self].

	(SystemWindow windowsIn: self world satisfying: [:w | w model canDiscardEdits])
		do: [:w | w delete]