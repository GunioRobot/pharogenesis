drawOn: aCanvas
	"Put the painting on the display"

	paintingForm ifNotNil: [
		aCanvas paintImage: paintingForm at: bounds origin].

 