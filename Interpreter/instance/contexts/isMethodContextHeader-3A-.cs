isMethodContextHeader: aHeader
	self inline: true.
	^ ((aHeader >> 12) bitAnd: 16r1F) = 14