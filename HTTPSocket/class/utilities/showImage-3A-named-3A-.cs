showImage: image named: imageName
	Smalltalk isMorphic
		ifTrue: [HandMorph attach: (SketchMorph withForm: image)]
		ifFalse: [FormView open: image named: imageName]