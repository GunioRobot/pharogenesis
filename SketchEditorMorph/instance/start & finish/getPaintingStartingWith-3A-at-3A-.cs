getPaintingStartingWith: initialForm at: aRectangle

	canvasRectangle _ bounds translateBy: self world viewBox origin.
	paintingForm _ Form extent: canvasRectangle extent 
		depth: self world canvas depth.

	self dimTheWindow.	"And set up the bitBlts"

	initialForm ~~ nil ifTrue:
		["paintingForm copy: (0@0 extent: aRectangle extent) 
			from: 0@0 in: initialForm form rule: Form over."
		initialForm displayOn: paintingForm 
			at: (aRectangle origin - bounds origin)
			clippingBox: (0@0 extent: paintingForm extent)
			rule: Form over
			fillColor: nil.
			"assume they are the same depth"
		"initialForm displayOn: Display 
			at: (aRectangle translateBy: canvasRectangle origin) origin
			clippingBox: (aRectangle translateBy: canvasRectangle origin)
			rule: Form over
			fillColor: nil."
		].

	^ self resumePainting.	
