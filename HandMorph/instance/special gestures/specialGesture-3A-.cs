specialGesture: evt
	"Blue mouse button (cmd-mouse on the Macintosh) gestures that allow a morph to be grabbed without recourse to the meta menu or brings up a halo of handles for the morph."
	"Summary:
		Cmd-mouse			pop up halo
		Cmd-shift-mouse		grab morph (for picking up buttons, etc.)"

	"if carrying morphs, just drop them"
	self hasSubmorphs ifTrue: [^ self dropMorphsEvent: evt].

	targetOffset _ menuTargetOffset _ self position.
	(argument _ self argumentOrNil) ifNil: [^ self].
	evt shiftPressed
		ifTrue: [self grabMorph]
		ifFalse: [self popUpHalo: evt].
