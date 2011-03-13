changeModelSelection: anInteger
	"Change the model's selected item index to be anInteger."
	| newIndex |
	newIndex := anInteger.
	(autoDeselect == nil or: [autoDeselect]) ifTrue:
		[getSelectionSelector ifNotNil:
			[(model perform: getSelectionSelector) = anInteger ifTrue:
				["Click on existing selection deselects"
				newIndex := 0]]].

	setSelectionSelector ifNotNil:
		[model perform: setSelectionSelector with: newIndex].