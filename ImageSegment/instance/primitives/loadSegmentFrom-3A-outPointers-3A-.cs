loadSegmentFrom: segmentWordArray outPointers: outPointerArray
	"This primitive will install a binary image segment and return as its value the array of roots of the tree of objects represented.  Upon successful completion, the wordArray will have been transmuted into an object of zero length.  If this primitive should fail, it will have destroyed the contents of the segment wordArray."

	<primitive: 99>	"successful completion returns the array of roots"
	^ nil			"failure returns nil"