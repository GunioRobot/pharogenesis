initializeFor: aSelector
	"Initialize the receiver to have the given selector"

	selector := aSelector.
	attributeKeywords := OrderedCollection new.
	defaultStatus := #normal
