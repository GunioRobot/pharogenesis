openThreeDSFile
	| menu result newFileString myScene |
	menu := StandardFileMenu oldFileMenu: (FileDirectory default) withPattern: '*.3ds'.
	result := menu startUpWithCaption: 'Select 3DS model file ...'.
	result ifNotNil: [	
		newFileString := (result directory pathName),(result directory pathNameDelimiter asString),(result name).
		myScene := (B3DScene withoutQuestionsFrom3DS: (ThreeDSParser parseFileNamed: newFileString)).
		self scene: myScene].