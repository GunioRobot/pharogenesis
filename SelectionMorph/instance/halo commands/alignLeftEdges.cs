alignLeftEdges
	"Make the left coordinate of all my elements be the same"

	| minLeft |
	selectedItems ifEmpty: [^ self].
	minLeft := (selectedItems collect: [:itm | itm left]) min.
	selectedItems do:
		[:itm | itm left: minLeft]