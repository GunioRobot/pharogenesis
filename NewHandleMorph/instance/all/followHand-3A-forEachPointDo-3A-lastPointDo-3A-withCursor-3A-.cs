followHand: aHand forEachPointDo: block1 lastPointDo: block2 withCursor: aCursor
	hand _ aHand.
	hand showTemporaryCursor: aCursor "hotSpotOffset: aCursor offset negated".
	borderWidth _ 0.
	color _ Color transparent.
	pointBlock _ block1.
	lastPointBlock _ block2.
	self position: hand lastEvent cursorPoint - (self extent // 2)