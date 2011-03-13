layoutChanged
	"Update rotatedForm and compute new bounds."
	self changed.
	self generateRotatedForm.
	bounds _ bounds origin extent: rotatedForm extent.
	super layoutChanged.
	self changed.
