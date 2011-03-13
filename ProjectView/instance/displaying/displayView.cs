displayView
	| scale rect topLeft |
	super displayView.
	self label = model name
		ifFalse: [super relabel: model name].
	self isCollapsed ifTrue: [^ self].
	Display fill: self insetDisplayBox fillColor: Color lightGray.
	scale _ self insetDisplayBox extent / Display extent.
	topLeft _ self insetDisplayBox topLeft.
	model views reverseDo:
		[:v | rect _ (v displayBox scaleBy: scale) rounded
				translateBy: topLeft.
		Display fill: rect fillColor: v backgroundColor;
			border: rect width: 1;
			border: (rect topLeft extent: rect width@3) width: 1.
		]