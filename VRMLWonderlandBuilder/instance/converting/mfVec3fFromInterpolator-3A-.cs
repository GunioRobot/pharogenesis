mfVec3fFromInterpolator: node
	| key value len values vv keySize |
	key _ node attributeValueNamed: 'key'.
	value _ node attributeValueNamed: 'keyValue'.
	keySize _ key size.
	values _ Array new: keySize.
	len _ value size // keySize.
	1 to: values size do:[:i|
		vv _ B3DVector3Array new: len.
		vv replaceFrom: 1 to: len with: value startingAt: (i-1 * len)+1.
		values at: i put: (self mfVec3fFrom: vv).
	].
	^values