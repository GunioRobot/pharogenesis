drawOn: aCanvas 
	"Only modification here is to bypass the #drawOn: method in our superclass."

	super superDrawOn: aCanvas.
	selectedMorph
		ifNotNil: [aCanvas
				fillRectangle: (((scroller transformFrom: self)
						localBoundsToGlobal: selectedMorph bounds)
						intersect: scroller bounds)
				color: color darker]