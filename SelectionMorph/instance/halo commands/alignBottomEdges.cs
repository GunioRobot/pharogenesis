alignBottomEdges
	"Make the bottom coordinate of all my elements be the same"

	| maxBottom |
	maxBottom _ (selectedItems collect: [:itm | itm bottom]) max.
	selectedItems do:
		[:itm | itm bottom: maxBottom].

	self changed
