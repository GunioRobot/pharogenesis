isContextHeader: aHeader
	| ccIndex |
	self inline: true.
	ccIndex _ (aHeader >> 12) bitAnd: 16r1F.
	^ ccIndex = 13 or: [ccIndex = 14]