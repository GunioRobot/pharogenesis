objectRepresented: anObject
	"Set the object represented by the receiver to be as requested"

	objectRepresented _ anObject.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.
	self setNameTo: anObject name.
	self removeAllMorphs.
