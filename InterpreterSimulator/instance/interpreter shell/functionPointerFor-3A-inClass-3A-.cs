functionPointerFor: primIndex inClass: lookupClass
"Override Interpreter to handle the external primitives caching. See also internalExecuteNewMethod"
	(primIndex between: 1 and: MaxPrimitiveIndex) ifFalse:[^nil].
	^primitiveTable at: primIndex +1