inspectorWithTrash: anInspector 
	"Create an inspector with an extra 'trash' view at the bottom,
	where you can type expressions that don't interfere with
	inspecting the various selectable fields."

	| inspectorView aTrashView threeView |
	threeView _ View new model: anInspector object.
	inspectorView _ self inspector: anInspector.
	threeView addSubView: inspectorView.
	aTrashView _ self buildTrashView: anInspector.
	threeView
		addSubView: aTrashView
		align: aTrashView viewport topLeft
		with: inspectorView viewport bottomLeft.
	^ threeView