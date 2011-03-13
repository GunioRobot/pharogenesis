saveScript

	| newScript scriptName |
	newScript _ self compileScript.
	scriptName _ FillInTheBlank 
		request: 'Name this script' 
		initialAnswer: (self valueOfProperty: #cameraScriptName ifAbsent: ['']).
	scriptName isEmptyOrNil ifTrue: [^self].
	(self valueOfProperty: #cameraController)
		saveScript: newScript
		as: scriptName.
	self delete.