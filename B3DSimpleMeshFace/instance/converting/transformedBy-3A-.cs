transformedBy: aMatrix
	"Return a copy of the receiver with its vertices transformed by the given matrix"
	| newVtx |
	newVtx _ Array new: self size.
	1 to: self size do:[:i| newVtx at: i put: ((self at: i) transformedBy: aMatrix)].
	^self class withAll: newVtx