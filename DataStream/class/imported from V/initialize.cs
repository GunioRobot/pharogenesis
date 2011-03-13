initialize
	"TypeMap maps Smalltalk classes to type ID numbers which identify the data stream primitive formats.  nextPut: writes these IDs to the data stream.  NOTE: Changing these type ID numbers will invalidate all extant data stream files.  Adding new ones is OK.
	 See nextPut:, next, typeIDFor:, & ReferenceStream>>isAReferenceType:"
	"DataStream initialize"

	| refTypes t |
	refTypes _ OrderedCollection new.
	t _ TypeMap _ Dictionary new: 30. "sparse for fast hashing"

	t at: UndefinedObject put: 1.   refTypes add: 0.
	t at: True put: 2.   refTypes add: 0.
	t at: False put: 3.   refTypes add: 0.
	t at: SmallInteger put: 4.	 refTypes add: 0.
	t at: String put: 5.   refTypes add: 1.
	t at: Symbol put: 6.   refTypes add: 1.
	t at: ByteArray put: 7.   refTypes add: 1.
		"Does anything use this?"
	t at: Array put: 8.   refTypes add: 1.
	"(type ID 9 is for arbitrary instances, cf. typeIDFor:)"
		refTypes add: 1.
	"(type ID 10 is for references, cf. ReferenceStream>>tryToPutReference:)"
		refTypes add: 0.
	t at: Bitmap put: 11.   refTypes add: 1.
	t at: Metaclass put: 12.   refTypes add: 0.
	"Type ID 13 is used for HyperSqueak User classes that must be reconstructed."
		refTypes add: 1.
	t at: Float put: 14.  refTypes add: 1.
	"t at:  put: 15.  refTypes add: 0."
	ReferenceStream refTypes: refTypes.	"save it"