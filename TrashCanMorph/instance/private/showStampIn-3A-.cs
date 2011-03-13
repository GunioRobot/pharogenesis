showStampIn: aHand
	"If painting and in stamp mode, show the stamp that is about to be thrown away."

	| paintBox curs |
	paintBox _ self findActivePaintBox.
	paintBox ifNotNil: [
		"See if a stamp is being dropped into the trash. It is not actually held by the hand."
		paintBox getSpecial == #stamp: ifTrue: [
			curs _ paintBox actionCursor.
			aHand showTemporaryCursor: curs hotSpotOffset: curs center]].
