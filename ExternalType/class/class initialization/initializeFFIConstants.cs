initializeFFIConstants
	"ExternalType initialize"
	| dict |
	AtomicTypeNames _ IdentityDictionary new.
	AtomicSelectors _ IdentityDictionary new.
	dict _ Smalltalk at: #FFIConstants ifAbsentPut:[Dictionary new].
	#(
		"type void"
		(FFITypeVoid 0 'void'	voidAt:)
		"type bool"
		(FFITypeBool 1 'bool'		booleanAt:)

		"basic integer types.
		note: (integerType anyMask: 1) = integerType isSigned"

		(FFITypeUnsignedByte 2	'byte' 		unsignedByteAt:)
		(FFITypeSignedByte 3 	'sbyte' 		signedByteAt:)
		(FFITypeUnsignedShort 4	'ushort'		unsignedShortAt:)
		(FFITypeSignedShort 5 	'short'		signedShortAt:)
		(FFITypeUnsignedInt 6	'ulong'		unsignedLongAt:)
		(FFITypeSignedInt 7		'long'		signedLongAt:)

		"64bit types"
		(FFITypeUnsignedLongLong 8 'ulonglong'			unsignedLongLongAt:)
		(FFITypeSignedLongLong 9 'longlong'				signedLongLongAt:)

		"special integer types"
		(FFITypeUnsignedChar 10		'char'		unsignedCharAt:)
		(FFITypeSignedChar 11 		'schar'		signedCharAt:)

		"float types"
		(FFITypeSingleFloat 12 	'float'		floatAt:)
		(FFITypeDoubleFloat 13 	'double'		doubleAt:)

		"type flags"
		(FFIFlagAtomic 16r40000) "type is atomic"
		(FFIFlagPointer 16r20000) "type is pointer to base type"
		(FFIFlagStructure  16r10000) "baseType is structure of 64k length"
		(FFIStructSizeMask 16rFFFF) "mask for max size of structure"
		(FFIAtomicTypeMask 16r0F000000) "mask for atomic type spec"
		(FFIAtomicTypeShift 24) "shift for atomic type"
	) do:[:spec|
		dict declare: spec first from: Undeclared.
		dict at: spec first put: spec second.
		spec size > 2 ifTrue:[
			AtomicTypeNames at: spec second put: spec third.
			AtomicSelectors at: spec second put: spec fourth].
	].