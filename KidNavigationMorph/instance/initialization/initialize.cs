initialize
	"initialize the state of the receiver"
	| |
	super initialize.
	""
	self layoutInset: 12.

	self removeAllMorphs.
	self addButtons