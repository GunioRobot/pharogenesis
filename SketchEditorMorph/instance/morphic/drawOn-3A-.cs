drawOn: aCanvas
	"Put the painting on the display"

	paintingForm ifNotNil: [
		aCanvas image: paintingForm at: bounds origin].

 