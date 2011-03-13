formDictionaryInspector: anInspector 
	"Answer an instance of me on the model, anInspector. The instance 
	consists of an InspectListView and an InspectFormView  6/28/96 sw."

	| anInspectorView anInspectorListView aFormView |
	anInspectorView _ View new.
		anInspectorView model: anInspector.
		anInspectorListView _ InspectListView new.
		anInspectorListView model: anInspector;
				controller: DictionaryListController new.
		anInspectorListView window: (0 @ 0 extent: 40 @ 40).
		anInspectorListView borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
	anInspectorView addSubView: anInspectorListView.
	aFormView _ self buildFormView: anInspector.
	anInspectorView
		addSubView: aFormView
		align: aFormView viewport topLeft
		with: anInspectorListView viewport topRight.
	^anInspectorView