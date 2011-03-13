isContextHeader: aHeader
	| ccIndex |
	self inline: true.
	ccIndex _ (aHeader >> 12) bitAnd: 16r1F.
	^ ccIndex = 13			"MethodContext"
		or: [ccIndex = 14		"BlockContext"
		or: [ccIndex = 4]]	"PseudoContext"