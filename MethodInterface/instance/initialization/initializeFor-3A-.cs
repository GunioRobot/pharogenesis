initializeFor: aSelector
	"Initialize the receiver to have the given selector"

	selector _ aSelector.
	attributeKeywords _ OrderedCollection new.
	defaultStatus _ #normal
