become: array1 with: array2
	"All references to each object in array1 are swapped with all references to the corresponding object in array2. That is, all pointers to one object are replaced with with pointers to the other. The arguments must be arrays of the same length. Returns true if the primitive succeeds."
	"Implementation: Uses forwarding blocks to update references as done in compaction."

	(self fetchClassOf: array1) = (self splObj: ClassArray) ifFalse: [ ^ false ].
	(self fetchClassOf: array2) = (self splObj: ClassArray) ifFalse: [ ^ false ].
	(self lastPointerOf: array1) = (self lastPointerOf: array2) ifFalse: [ ^ false ].
	(self containOnlyOops: array1 and: array2) ifFalse: [ ^ false ].

	(self prepareForwardingTableForBecoming: array1 with: array2) ifFalse: [
		^ false  "fail; not enough space for forwarding table"
	].

	(self allYoung: array1 and: array2) ifTrue: [
		"sweep only the young objects plus the roots"
		self mapPointersInObjectsFrom: youngStart to: endOfMemory.
	] ifFalse: [
		"sweep all objects"
		self mapPointersInObjectsFrom: (self startOfMemory) to: endOfMemory.
	].

	self restoreHeadersAfterBecoming: array1 with: array2.
	self initializeMemoryFirstFree: freeBlock.  "re-initialize memory used for forwarding table"

	^ true  "success"