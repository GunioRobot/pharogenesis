showMenuOf: selectorCollection withFirstItem: firstItem ifChosenDo: choiceBlock
	"Show a sorted menu of the given selectors, preceded by firstItem, and all
	abbreviated to 40 characters.  Evaluate choiceBlock if a message is chosen."
	| index menuLabels sortedList |
	sortedList _ selectorCollection asSortedCollection.
	menuLabels _ String streamContents: 
		[:strm | strm nextPutAll: (firstItem contractTo: 40).
		sortedList do: [:sel | strm cr; nextPutAll: (sel contractTo: 40)]].
	index _ (PopUpMenu labels: menuLabels lines: #(1)) startUp.
	index = 1 ifTrue: [choiceBlock value: firstItem].
	index > 1 ifTrue: [choiceBlock value: (sortedList at: index-1)]