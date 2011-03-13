saveMorphInFile
	"Save the argument morph in a file."

	| fileName refStream copyToSave |
	fileName _ FillInTheBlank request: 'File name for this morph?'.
	fileName isEmpty ifTrue: [^ self].  "abort"
	copyToSave _ argument fullCopy.
	(copyToSave isKindOf: MorphicModel) ifTrue: [
		"don't save this world's model"
		copyToSave model: nil slotName: nil].
	copyToSave allMorphsDo: [:m | m prepareToBeSaved].
	refStream _ SmartRefStream newFileNamed: fileName, '.morph'.
	refStream nextPut: copyToSave.
	refStream close.
