inspect
	"Open an OrderedCollectionInspector on the receiver.
	Use basicInspect to get a normal type of inspector."

	InspectorView open: (InspectorView inspectorWithTrash:
		(OrderedCollectionInspector inspect: self))