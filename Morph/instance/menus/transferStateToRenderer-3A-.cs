transferStateToRenderer: aRenderer
	"Transfer knownName, and visible over to aRenderer, which is being imposed above me as a transformation shell"

	| current |
	(current := self knownName) ifNotNil:
		[aRenderer setNameTo: current.
		self setNameTo: nil].
	aRenderer simplySetVisible: self visible



 

		