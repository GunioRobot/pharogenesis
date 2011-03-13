selection: item
	"Called from outside to request setting a new selection.
	Assumes scroller submorphs is exactly our list.
	Note: won't work right if list includes repeated items"

	self selectionIndex: (scroller submorphs findFirst: [:m | m contents = item])