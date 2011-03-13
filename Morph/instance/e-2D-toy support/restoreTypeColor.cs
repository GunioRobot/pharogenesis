restoreTypeColor
	costumee ifNotNil: [costumee allScriptEditors do:
		[:anEditor | anEditor allMorphsDo:
			[:m | m restoreTypeColor]]]