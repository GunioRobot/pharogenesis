mouseLeave: event
	"The mouse has left the area of the receiver"

	textMorph ifNotNil: [selectionInterval _ textMorph editor selectionInterval].
	super mouseLeave: event.
	Preferences mouseOverForKeyboardFocus ifTrue:
		[event hand releaseKeyboardFocus: textMorph]