transformedBy: aMatrix
	"Return a copy of the receiver with its vertices transformed by the given matrix"
	| newFaces|
	newFaces _ Array new: self size.
	1 to: self size do:[:i| newFaces at: i put: ((self at: i) transformedBy: aMatrix)].
	^self class withAll: newFaces