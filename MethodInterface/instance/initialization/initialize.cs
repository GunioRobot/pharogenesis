initialize
	"Initialize the receiver"

	super initialize.
	attributeKeywords _ OrderedCollection new.
	defaultStatus _ #normal.
	defaultFiresPerTick _ 1.
