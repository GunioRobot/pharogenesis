extent: aPoint

	super extent: aPoint.
	inner extent: (self extent * ((1.0@1.0)-IrisSize)) asIntegerPoint.
	iris extent: (self extent * IrisSize) asIntegerPoint.
	inner position: (self center - (inner extent // 2)) asIntegerPoint.
