inspect
	"Open a DictionaryInspector on the receiver.  N.B.: this is
	an inspector without trash, since InspectorTrash doesn't do the
	obvious thing right now.  Use basicInspect to get a normal
	(less useful) type of inspector."

	DictionaryInspector openOn: self withEvalPane: false