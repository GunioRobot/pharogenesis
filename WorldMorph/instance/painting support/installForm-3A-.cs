installForm: aForm
	"Accept a Form from the outside, create a SketchMorph, and put it on the Hand."

	| f |
	f _ SketchMorph new form: aForm.
	hands first attachMorph: f.
