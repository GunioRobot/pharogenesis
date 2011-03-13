conflictMethodForArguments: aNumber ifAbsentPut: aBlock
	"ConflictMethods is an array that caches the generated conflict
	methods. At position 1: binary method; 2: unary method;
	n+2: keywordmethod with n arguments." 

	^(ConflictMethods at: aNumber)
		ifNil: [ConflictMethods at: aNumber put: aBlock value]