alignBottomEdges
	"Make the bottom coordinate of all my elements be the same"

	| maxBottom |
	selectedItems ifEmpty: [^ self].
	maxBottom := (selectedItems collect: [:itm | itm bottom]) max.
	selectedItems do:
		[:itm | itm bottom: maxBottom]