translateBy: aPoint 
	"Answer a new Quadrangle translated by aPoint.
	 5/24/96 sw: removed hard-coded class name so subclasses can gain same functionality."

	^ self class
		region: (super translateBy: aPoint)
		borderWidth: borderWidth
		borderColor: borderColor
		insideColor: insideColor