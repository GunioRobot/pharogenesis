inspectFormsWithLabel: aLabel
	"Open a Form Dictionary inspector on the receiver, with the given label.  6/28/96 sw"

	InspectorView open: (InspectorView formDictionaryInspector:
		(DictionaryInspector inspect: self)) withLabel: aLabel