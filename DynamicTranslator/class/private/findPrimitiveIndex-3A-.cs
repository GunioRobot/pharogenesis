findPrimitiveIndex: primitiveSelector
	self primitiveTable doWithIndex: [:sel :i | sel == primitiveSelector ifTrue: [^i - 1]].
	self error: 'primitive not found'