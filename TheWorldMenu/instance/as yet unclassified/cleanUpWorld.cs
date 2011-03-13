cleanUpWorld
	(SelectionMenu confirm:
'This will remove all windows except those
containing unsubmitted text edits, and will
also remove all non-window morphs (other
than flaps) found on the desktop.  Are you
sure you want to do this?')
		ifFalse: [^ self].

	myWorld allNonFlapRelatedSubmorphs do:
		[:m | m delete].
	(SystemWindow windowsIn: myWorld satisfying: [:w | w model canDiscardEdits])
		do: [:w | w delete]