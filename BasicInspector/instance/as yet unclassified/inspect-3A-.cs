inspect: anObject 
	"Initialize the receiver so that it is inspecting anObject. There is no 
	current selection."

	self initialize.
	object _ anObject.
	selectionIndex _ 0.
	contents _ ''