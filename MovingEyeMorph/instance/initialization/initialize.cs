initialize
	"initialize the state of the receiver"
	super initialize.
	""
	inner _ EllipseMorph new.
	inner color: self color.
	inner extent: (self extent * (1.0 @ 1.0 - IrisSize)) asIntegerPoint.
	inner borderColor: self color.
	inner borderWidth: 0.
""
	iris _ EllipseMorph new.
	iris color: Color white.
	iris extent: (self extent * IrisSize) asIntegerPoint.
""
	self addMorphCentered: inner.
	inner addMorphCentered: iris.
""
	self extent: 26 @ 33