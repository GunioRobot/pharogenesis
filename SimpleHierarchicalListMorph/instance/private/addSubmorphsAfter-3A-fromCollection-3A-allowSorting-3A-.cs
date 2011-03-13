addSubmorphsAfter: parentMorph fromCollection: aCollection allowSorting: sortBoolean

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
		priorMorph _ self indentingItemClass basicNew 
			initWithContents: item 
			prior: priorMorph 
			forList: self
			indentLevel: parentMorph indentLevel + 1.
		morphList add: priorMorph.
	].
	scroller addAllMorphs: morphList after: parentMorph.
	^morphList
	
