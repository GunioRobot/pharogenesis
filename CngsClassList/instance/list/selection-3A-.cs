selection: item
	"If this item is in the list, select it."
	| index |
	(index _ list indexOf: item) = 0 ifFalse: [
		listIndex == index ifFalse: [
				self toggleListIndex: index]
			ifTrue: [self changed: #listIndex.
				parent changed: #class]].