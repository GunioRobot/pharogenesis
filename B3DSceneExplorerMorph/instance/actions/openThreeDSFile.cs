openThreeDSFile
	| menu result newFileString myScene |
	menu := StandardFileMenu oldFileMenu: (FileDirectory default).
	result := menu startUpWithCaption: 'Select 3DS model file ...'.
	result ifNotNil: [	
		newFileString := (result directory pathName),(result directory pathNameDelimiter asString),(result name).
		myScene := (B3DScene withoutQuestionsFrom3DS: (ThreeDSParser parseFileNamed: newFileString)).
		myScene := self updateSceneWithDefaults: myScene.
		self scene: myScene.
		self updateUpVectorForCamera: self scene defaultCamera.].