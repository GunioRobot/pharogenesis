atAll: indexArray
	"Answer a new collection like the receiver which contains all elements
	of the receiver at the indices of indexArray."

	| newCollection |
	newCollection _ self species new: indexArray size.
	1 to: indexArray size do:
		[:index |
		newCollection at: index put: (self at: (indexArray at: index))].
	^ newCollection