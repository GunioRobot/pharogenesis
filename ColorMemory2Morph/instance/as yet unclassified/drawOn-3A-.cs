drawOn: aCanvas 
	"Image plus circles for selected places."

	| formCanvas ring |
	super drawOn: aCanvas.
	"Is canvas always a FormCanvas?"
	formCanvas _ aCanvas.
	locOfCurrent ifNotNil: [
		ring _ currentColor  contrastingRed. 
		formCanvas fillOval: (Rectangle center: locOfCurrent + self topLeft extent: 9@9) 
				color: Color transparent
				borderWidth: 1 borderColor: ring].