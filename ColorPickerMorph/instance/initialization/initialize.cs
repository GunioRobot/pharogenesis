initialize
	"Initialize the receiver.  Obey the modalColorPickers preference when deciding how to configure myself.  This is not quite satisfactory -- we'd like to have explicit calls tell us things like whether whether to be modal, whether to allow transparency, but for the moment, in grand Morphic fashion, this is rather inflexibly all housed right here"

	super initialize.
	self buildChartForm.
	
	selectedColor _ Color white.
	sourceHand _ nil.
	deleteOnMouseUp _ false.
	clickedTranslucency _ false.
	updateContinuously _ true.
	selector _ nil.
	target _ nil