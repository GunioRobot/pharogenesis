specialGesture: evt
	"Special gestures (cmd-mouse on the Macintosh) allow a mouse-sensitive morph to be grabbed or bring up a halo for the morph."
	"Summary:
		Cmd-mouse			pop up halo
		Cmd-shift-mouse		grab morph"

	"if carrying morphs, just drop them"
	self hasSubmorphs ifTrue: [^ self dropMorphsEvent: evt].

	targetOffset _ menuTargetOffset _ self position.
	argument _ self argumentOrNil.
	evt shiftPressed
		ifTrue: [argument ifNotNil: [self grabMorph]]
		ifFalse: [self popUpHaloFromClick: evt].
