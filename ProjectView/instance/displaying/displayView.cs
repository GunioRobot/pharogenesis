displayView
	super displayView.
	self label = model name
		ifFalse: [self setLabelTo: model name].
	self isCollapsed ifTrue: [^ self].
	model thumbnail ifNil: [^ self].
	self insetDisplayBox extent = model thumbnail extent
		ifTrue: [model thumbnail displayAt: self insetDisplayBox topLeft]
		ifFalse: [(model thumbnail
					magnify: model thumbnail boundingBox
					by: self insetDisplayBox extent asFloatPoint / model thumbnail extent) 				displayAt: self insetDisplayBox topLeft]
