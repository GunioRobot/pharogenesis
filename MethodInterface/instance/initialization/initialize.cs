initialize
	"Initialize the receiver"

	super initialize.
	attributeKeywords _ OrderedCollection new.
	defaultStatus _ #normal.
	argumentVariables _ OrderedCollection new
