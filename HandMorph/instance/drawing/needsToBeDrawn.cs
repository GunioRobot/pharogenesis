needsToBeDrawn
	"Return true if this hand must be drawn explicitely instead of being drawn via the hardware cursor. This is the case if it (a) it is a remote hand, (b) it is showing a temporary cursor, or (c) it is not empty. If using the software cursor, ensure that the hardware cursor is hidden."
	"Details:  Return true if this hand has a saved patch to ensure that is is processed by the world. This saved patch will be deleted after one final display pass when it becomes possible to start using the hardware cursor again. This trick gives us one last display cycle to allow us to remove the software cursor and shadow from the display."

	savedPatch ifNotNil: [^ true].  "always process if this hand has a saved patch"
	userInitials size > 0 ifTrue: [^ true].
	((submorphs size > 0) or:
	 [temporaryCursor ~~ nil])
		ifTrue: [
			"using the software cursor; hide the hardware one"
			Sensor currentCursor == Cursor blank ifFalse: [Cursor blank show].
			^ true].

	^ false
