drawOn: aCanvas
	"Clear the damageReported flag when redrawn."

	super drawOn: aCanvas.
	damageReported _ false.