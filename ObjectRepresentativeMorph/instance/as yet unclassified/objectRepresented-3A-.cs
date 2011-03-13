objectRepresented: anObject
	"Set the receiver's representee.  This clears out any preexisting state in the receiver"

	objectRepresented _ anObject.
	self removeAllMorphs.
	self hResizing: #shrinkWrap.  
	self vResizing: #shrinkWrap.
	self addMorphBack: (StringMorph new contents: anObject name asString).
	self setNameTo: anObject name
	