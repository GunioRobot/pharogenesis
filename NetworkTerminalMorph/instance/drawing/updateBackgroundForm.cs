updateBackgroundForm
	"make sure that our background form matches what the server has most recently requested"

	| drawingForm |

	drawingForm _ decoder drawingForm.
	(drawingForm extent = backgroundForm extent and: [
		drawingForm depth = backgroundForm depth ]) ifTrue: [
			"they match just fine"
			^self ].

	backgroundForm _ drawingForm deepCopy.		"need copy to capture the moment"
	self extent: backgroundForm extent.