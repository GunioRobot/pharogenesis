stepToNextWideLine
	"Process the current entry in the AET by stepping to the next scan line"
	self inline: true.
	^self stepToNextWideLineIn: (aetBuffer at: self aetStartGet) at: self currentYGet