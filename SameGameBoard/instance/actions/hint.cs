hint
	"find a possible selection and select it"

	| tile |
	self deselectSelection.
	tile _ self findSelection.
	tile ifNotNil: [tile mouseDown: MouseButtonEvent new]