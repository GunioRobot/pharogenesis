withAll: aCollection
	"Create a new collection containing all the elements from aCollection."

	^ (self new: (self sizeFor: aCollection))
		addAll: aCollection;
		yourself