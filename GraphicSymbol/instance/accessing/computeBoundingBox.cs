computeBoundingBox
	"Compute a boundingBox that encloses all of the Paths in this symbol"

	^Rectangle merging: (self collect: [:each | each computeBoundingBox])
