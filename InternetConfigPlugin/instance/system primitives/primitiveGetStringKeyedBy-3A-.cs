primitiveGetStringKeyedBy: aKey
	| oop ptr size aString keyLength |

	self primitive: 'primitiveGetStringKeyedBy'
		parameters: #(String).
	self var: #aString declareC: 'char aString[1025]'.
	self var: #ptr type: 'char *'.
	
	keyLength _ interpreterProxy byteSizeOf: aKey cPtrAsOop.
	size _ self sqInternetConfigurationGetStringKeyedBy: aKey keySize: keyLength into: aString.
	oop _ interpreterProxy instantiateClass: interpreterProxy classString indexableSize: size.
	ptr _ interpreterProxy firstIndexableField: oop.
	0 to: size-1 do:[:i|
		ptr at: i put: (aString at: i)].
	^oop.
