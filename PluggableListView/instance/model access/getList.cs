getList 
	"Answer the list to be displayed."

	| lst |
	getListSelector == nil ifTrue: [^ #()].
	lst := model perform: getListSelector.
	lst == nil ifTrue: [^ #()].
	^ lst