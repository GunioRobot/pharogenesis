morphsFromCollection: aCollection allowSorting: sortBoolean withExpandedItems: expandedItems

	| priorMorph morphList newCollection |
	priorMorph _ nil.
	newCollection _ (sortBoolean and: [sortingSelector notNil]) ifTrue: [
		(aCollection asSortedCollection: [ :a :b | 
			(a perform: sortingSelector) <= (b perform: sortingSelector)]) asOrderedCollection
	] ifFalse: [
		aCollection
	].
	morphList _ OrderedCollection new.
	newCollection do: [:item | 
		priorMorph _ IndentingListItemMorph basicNew 
			initWithContents: item 
			prior: priorMorph 
			forList: self.
		morphList add: priorMorph.
		(item hasEquivalentIn: expandedItems) ifTrue: [
			priorMorph isExpanded: true.
			priorMorph 
				addChildrenForList: self 
				addingTo: morphList
				withExpandedItems: expandedItems.
		].
	].
	^morphList
	
