addGraphic

	graphic _ SketchMorph new form: self speakerGraphic.
	graphic position: bounds center - (graphic extent // 2).
	self addMorph: graphic.
