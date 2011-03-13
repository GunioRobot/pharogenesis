inspect: anObject 
	"Initialize the receiver so that it is inspecting anObject."
	fieldList _ nil.
	super inspect: anObject.
	msgListIndex _ 0.
	self changed: #msgText