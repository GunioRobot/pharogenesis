paintBackground
	| pic rect |
	self world prepareToPaint.
	pic _ self backgroundSketch.
	pic ifNotNil: [pic editDrawingIn: self forBackground: true]		"need to resubmit it? (tck comment)"
		ifNil: [rect _ self bounds.
			pic _ self world drawingClass new form: 
				(Form extent: rect extent depth: Display depth).
			pic bounds: rect.
			"self world addMorphBack: pic.  done below"
			pic _ self backgroundSketch: pic.	"returns a different guy"
			pic ifNotNil: [pic editDrawingIn: self forBackground: true]]