dictionaryInspector: anInspector 
	"Answer an instance of me on the model, anInspector. The instance 
	consists of an InspectListView and an InspectCodeView."

	| anInspectorView anInspectorListView aCodeView |
	anInspectorView _ View new.
		anInspectorView model: anInspector.
		anInspectorListView _ InspectListView new.
		anInspectorListView model: anInspector;
				controller: DictionaryListController new.
		anInspectorListView window: (0 @ 0 extent: 40 @ 40).
		anInspectorListView borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
	anInspectorView addSubView: anInspectorListView.
	aCodeView _ self buildCodeView: anInspector.
	anInspectorView
		addSubView: aCodeView
		align: aCodeView viewport topLeft
		with: anInspectorListView viewport topRight.
	^anInspectorView