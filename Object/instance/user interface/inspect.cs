inspect
	"Create and schedule an Inspector in which the user can examine the 
	receiver's variables."
	InspectorView open: (InspectorView inspectorWithTrash: (Inspector inspect: self))
