alignRightEdges
	"Make the right coordinate of all my elements be the same"

	| maxRight |
	selectedItems ifEmpty: [^ self].
	maxRight := (selectedItems collect: [:itm | itm right]) max.
	selectedItems do:
		[:itm | itm right: maxRight]