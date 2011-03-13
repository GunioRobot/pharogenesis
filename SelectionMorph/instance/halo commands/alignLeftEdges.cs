alignLeftEdges
	"Make the left coordinate of all my elements be the same"

	| minLeft |
	minLeft _ (selectedItems collect: [:itm | itm left]) min.
	selectedItems do:
		[:itm | itm left: minLeft].

	self changed
