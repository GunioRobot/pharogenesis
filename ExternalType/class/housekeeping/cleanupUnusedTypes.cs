cleanupUnusedTypes
	"ExternalType cleanupUnusedTypes"
	| value |
	StructTypes keys do:[:key|
		value _ StructTypes at: key.
		value == nil ifTrue:[StructTypes removeKey: key ifAbsent:[]]].