getCurrentSelectionIndex
	"Answer the index of the current selection."
	| item |
	getSelectionSelector == nil ifTrue: [^ 0].
	item := model perform: getSelectionSelector.
	^ itemList findFirst: [ :x | x = item]
