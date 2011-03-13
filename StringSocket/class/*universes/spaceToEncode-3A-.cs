spaceToEncode: stringArray
	^stringArray inject: 4 into: [ :sum :array |
		sum + (array size + 4) ].