asSortedCollection
	"Answer a SortedCollection whose elements are the elements of the 
	receiver. The sort order is the default less than or equal."

	| aSortedCollection |
	aSortedCollection _ SortedCollection new: self size.
	aSortedCollection addAll: self.
	^aSortedCollection