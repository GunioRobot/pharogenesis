stepToNextBezier
	"Process the current entry in the AET by stepping to the next scan line"
	self inline: true.
	^self stepToNextBezierIn: (aetBuffer at: self aetStartGet) at: self currentYGet