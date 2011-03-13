inspectWithLabel: aLabel
	"Open a NewDictionaryInspector on the receiver.  N.B.: this is
	an inspector without trash, since InspectorTrash doesn't do the
	obvious thing right now.  Use basicInspect to get a normal
	(less useful) type of inspector."
	InspectorView open: (InspectorView dictionaryInspector:
		(DictionaryInspector inspect: self)) withLabel: aLabel