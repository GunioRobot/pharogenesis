initializeDefaultTypes
	"ExternalType initialize"
	| type pointerType |
	AtomicTypes = nil ifTrue:[
		"Create new atomic types and setup the dictionaries"
		AtomicTypes _ Dictionary new.
		StructTypes _ WeakValueDictionary new.
		AtomicTypeNames valuesDo:[:k|
			type _ self basicNew.
			pointerType _ self basicNew.
			AtomicTypes at: k put: type.
			type setReferencedType: pointerType.
			pointerType setReferencedType: type.
		].
	].
	self initializeAtomicTypes.
	self initializeStructureTypes.
	"AtomicTypes _ nil"