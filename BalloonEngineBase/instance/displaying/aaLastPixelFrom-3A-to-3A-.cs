aaLastPixelFrom: leftX to: rightX
	"Common function to compute the last full pixel for AA drawing"
	self inline: true.
	^(rightX - 1) bitAnd: (self aaLevelGet - 1) bitInvert32.