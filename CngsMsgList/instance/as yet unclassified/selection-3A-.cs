selection: item
	"If this item is in the list, select it."
	| index |
	(index _ list indexOf: item) = 0 ifFalse: [
		
		self toggleListIndex: index.
		self changed: #listIndex.
"		self toggleListIndex: index."
		" listIndex _ index. "].