insertToAET: edge beforeIndex: index
	"Insert the given edge into the AET."
	| i |
	self inline: false.
	"Make sure we have space in the AET"
	(self allocateAETEntry: 1) ifFalse:[^nil]. "Insufficient space in AET"

	i _ self aetUsedGet-1.
	[i < index] whileFalse:[
		aetBuffer at: i+1 put: (aetBuffer at: i).
		i _ i - 1.
	].
	aetBuffer at: index put: edge.
	self aetUsedPut: self aetUsedGet + 1.