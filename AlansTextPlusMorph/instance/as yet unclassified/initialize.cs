initialize

	super initialize.
	color _ Color white.
	thePasteUp _ TextPlusPasteUpMorph new borderWidth: 0; color: color.
	scroller addMorph: thePasteUp.
	theTextMorph _ TextPlusMorph new position: 4@4; scrollerOwner: self.
	thePasteUp theTextMorph: theTextMorph.
	self position: 100@100.
	self extent: Display extent // 3.
	self useRoundedCorners.
