on: aString mode: anInteger onErrorDo: aBlock

	source _ aString.
	compiledScript _ ApplescriptGeneric compile: aString mode: anInteger.
	compiledScript ifNil: [^aBlock value].
	^self