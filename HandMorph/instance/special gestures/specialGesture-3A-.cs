specialGesture: evt
	"Special gestures (cmd-mouse on the Macintosh) allow a mouse-sensitive morph to be moved or bring up a halo for the morph."
	"Summary:
		Cmd-click			pop up halo
		Cmd-drag			reposition morph"

	Preferences cmdGesturesEnabled ifFalse: [^ self].

	self newMouseFocus: nil.

	"if carrying morphs, just drop them"
	self hasSubmorphs ifTrue: [^ self dropMorphsEvent: evt].

	targetOffset _ menuTargetOffset _ self position.
	argument _ self argumentOrNil.
	evt shiftPressed
		ifFalse:	[self popUpHaloFromClick: evt]
		ifTrue:	[self popUpHaloFromShiftClick: evt]
