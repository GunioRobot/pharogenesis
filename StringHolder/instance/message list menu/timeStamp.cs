timeStamp 
	|  selector  aMethod |
	(selector _ self selectedMessageName) ifNotNil:
		[aMethod _ self selectedClassOrMetaClass compiledMethodAt: selector ifAbsent: [nil].
		aMethod ifNotNil: [^ Utilities timeStampForMethod: aMethod]].
	^ String new