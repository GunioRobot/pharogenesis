getCurrentSelectionIndex
	"Answer the index of the current selection."
	| item |
	getIndexSelector == nil ifTrue: [^ 0].
	item _ model perform: getIndexSelector.
	^ itemList findFirst: [ :x | x = item]
