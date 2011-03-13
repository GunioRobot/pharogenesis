color: aColor
	"Set the pane color."
	
	(self valueOfProperty: #fillStyle ifAbsent: []) ifNil: [
		super color: aColor]