getSharedMeshDict
	"Return the shared mesh dictionary"

	^ sharedMeshDict ifNil:[sharedMeshDict := Dictionary new].