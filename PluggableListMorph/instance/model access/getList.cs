getList 
	"Answer the list to be displayed."
	| lst |
	getListSelector == nil ifTrue: [^ #()].
	lst _ model perform: getListSelector.
	lst == nil ifTrue: [^ #()].
	^ lst