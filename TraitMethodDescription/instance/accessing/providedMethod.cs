providedMethod
	^self providedLocatedMethod ifNotNilDo: [:locatedMethod | locatedMethod method]