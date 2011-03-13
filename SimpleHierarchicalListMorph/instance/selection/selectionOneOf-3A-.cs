selectionOneOf: aListOfItems
	"Set the selection to the first item in the list which is represented by one of my submorphs"

	| index |
	aListOfItems do: [ :item |
		index := scroller submorphs findFirst: [:m | 
			m withoutListWrapper = item withoutListWrapper
		].
		index > 0 ifTrue: [^self selectionIndex: index].
	].
	self selectionIndex: 0.