extent: aPoint
	"Do it normally"
	
	self changed.
	bounds _ bounds topLeft extent: aPoint.
	self layoutChanged.
	self changed.
