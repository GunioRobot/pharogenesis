playerRepresented: anObject
	"Set the value of playerRepresented"

	playerRepresented _ anObject.
	self rebuildRow.
	self setNameTo: anObject costume topRendererOrSelf externalName