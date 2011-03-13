followHand: aHand forEachPointDo: block1 lastPointDo: block2
	hand _ aHand.
	pointBlock _ block1.
	lastPointBlock _ block2.
	self position: hand lastEvent cursorPoint - (self extent // 2)