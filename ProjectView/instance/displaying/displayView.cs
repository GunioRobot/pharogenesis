displayView
	super displayView.
	self label = model name
		ifFalse: [super relabel: model name].
	self isCollapsed ifTrue: [^ self].
	model thumbnail ifNotNil:
		[model thumbnail displayAt: self insetDisplayBox topLeft]
