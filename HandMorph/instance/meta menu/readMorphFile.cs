readMorphFile
	"Retreive a morph or a collection of morphs from a file."

	| fileName morphOrList ff |
	fileName _ FillInTheBlank request: 'Morph file name?'.
	fileName isEmpty ifTrue: [^ self].  "abort"

	ff _ FileStream oldFileNamed: fileName, '.morph'.
	morphOrList _ ff fileInObjectAndCode.		"code filed in is the Model class"

	"the file may contain either a single morph or an array of morphs"
	self world addMorphsAndModel: morphOrList.