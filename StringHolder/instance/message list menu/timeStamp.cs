timeStamp
	"Answer the time stamp for the chosen class and method, if any, else an empty string"

	|  selector  aMethod |
	(selector _ self selectedMessageName) ifNotNil:
		[self selectedClassOrMetaClass 
			ifNil:
				[^ String new]
			ifNotNil:
				[aMethod _ self selectedClassOrMetaClass compiledMethodAt: selector ifAbsent: [nil].
				aMethod ifNotNil: [^ Utilities timeStampForMethod: aMethod]]].
	^ String new