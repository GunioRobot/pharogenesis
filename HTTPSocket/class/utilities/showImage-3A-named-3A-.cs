showImage: image named: imageName
	Smalltalk isMorphic
		ifTrue: [HandMorph attach: (World drawingClass withForm: image)]
		ifFalse: [FormView open: image named: imageName]