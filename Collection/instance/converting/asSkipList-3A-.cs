asSkipList: aSortBlock 
	"Answer a SkipList whose elements are the elements of the 
	receiver. The sort order is defined by the argument, aSortBlock."

	| skipList |
	skipList _ SortedCollection new: self size.
	skipList sortBlock: aSortBlock.
	skipList addAll: self.
	^ skipList