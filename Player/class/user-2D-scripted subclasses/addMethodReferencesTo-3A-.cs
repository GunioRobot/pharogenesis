addMethodReferencesTo: aCollection
	"For each extant script in the receiver, add a MethodReference object"

	| sel |
	self scripts do:
		[:aScript |
			(sel _ aScript selector) ifNotNil:
				[aCollection add: (MethodReference new setStandardClass: self methodSymbol: sel)]]