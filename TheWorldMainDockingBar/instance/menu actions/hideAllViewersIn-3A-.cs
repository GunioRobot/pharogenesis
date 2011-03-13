hideAllViewersIn: aMorph 
	aMorph isFlapTab
		ifTrue: [self hideAllViewersIn: aMorph referent].
	aMorph
		submorphsDo: [:each | ""
			({ScriptEditorMorph. StandardViewer} includes: each class)
				ifTrue: [each dismiss]
				ifFalse: [self hideAllViewersIn: each]]