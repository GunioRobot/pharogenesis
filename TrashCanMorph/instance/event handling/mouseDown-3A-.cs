mouseDown: evt
	| paintBox palette |
	self currentHand endDisplaySuppression.
	"See if a stamp is being dropped into the trash. It is not held by the hand."
	(paintBox _ self findActivePaintBox) ifNotNil: [
		paintBox getSpecial == #stamp: ifTrue: [
			paintBox deleteCurrentStamp.  "throw away stamp..."
			self primaryHand showTemporaryCursor: nil.
			^ self]].	  "... and don't open trash"
	palette _ self standardPalette.
	((palette notNil and: [palette isInWorld]) and: [palette hasScrapsTab])
		ifTrue:
			[palette showScrapsTab]
		ifFalse:
			[self currentHand openScrapsBook]
