inspector: anInspector 
	"Answer an instance of me on the model, anInspector. The instance 
	consists of an InspectListView and an InspectCodeView."

	| anInspectorView anInspectorListView aCodeView |
	anInspectorView _ View new.
	anInspectorView model: anInspector.
	anInspectorListView _ self buildInspectListView: anInspector.
	anInspectorView addSubView: anInspectorListView.
	aCodeView _ self buildCodeView: anInspector.
	anInspectorView
		addSubView: aCodeView
		align: aCodeView viewport topLeft
		with: anInspectorListView viewport topRight.
	^anInspectorView