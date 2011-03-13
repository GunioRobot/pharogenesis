currentValueIn: aContext

	aContext ifNil: [^nil].
	^((self variableGetterBlockIn: aContext) ifNil: [^nil]) value printString
	

