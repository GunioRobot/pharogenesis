resumePlayIn: aWorld

	playHand _ HandMorphForReplay new recorder: self.
	playHand position: tapeStream peek position.
	aWorld addHand: playHand.
	playHand newKeyboardFocus: aWorld.
	playHand userInitials: 'play' andPicture: nil.

	lastEvent _ nil.
	lastDelta _ 0@0.
	state _ #play.

	self synchronize.
