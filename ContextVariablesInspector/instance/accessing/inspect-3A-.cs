inspect: anObject 
	"Initialize the receiver so that it is inspecting anObject. There is no 
	current selection.
	
	Because no object's inspectorClass method answers this class, it is OK for this method to
	override Inspector >> inspect: "

	object := anObject.
	self initialize
	