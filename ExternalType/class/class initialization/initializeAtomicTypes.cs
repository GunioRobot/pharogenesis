initializeAtomicTypes
	"ExternalType initialize"
	| atomicType byteSize type typeName |
	#(
		"name		atomic id		byte size"
		('void' 		0 				0)
		('bool' 		1 				1)
		('byte' 		2 				1)
		('sbyte' 	3 				1)
		('ushort' 	4 				2)
		('short' 		5 				2)
		('ulong' 	6 				4)
		('long' 		7 				4)
		('ulonglong' 8 				8)
		('longlong' 	9 				8)
		('char' 		10 				1)
		('schar' 	11 				1)
		('float' 		12 				4)
		('double' 	13 				8)
	) do:[:spec|
		typeName _ spec first.
		atomicType _ spec second.
		byteSize _ spec third.
		spec _ WordArray with: ((byteSize bitOr: FFIFlagAtomic) bitOr:
				(atomicType bitShift: FFIAtomicTypeShift)).
		type _ (AtomicTypes at: typeName).
		type compiledSpec: spec.
		spec _ WordArray with: ((self pointerSpec bitOr: FFIFlagAtomic) bitOr:
				(atomicType bitShift: FFIAtomicTypeShift)).
		type asPointerType compiledSpec: spec.
	].