saveMorphInFile
	"Save the argument morph in a file."

	| fileName refStream copyToSave |
	fileName _ FillInTheBlank request: 'File name for this morph?'.
	fileName isEmpty ifTrue: [^ self].  "abort"
	refStream _ SmartRefStream newFileNamed: fileName, '.morph'.
	copyToSave _ argument fullCopy.
	(copyToSave isKindOf: MorphicModel) ifTrue: [
		"don't save this world's model"
		copyToSave model: nil slotName: nil].
	copyToSave allMorphsDo: [:m | m prepareToBeSaved].
	refStream nextPut: copyToSave.
	refStream close.

	"Warn user if plain morph had behavior that is not saved"
	(copyToSave isKindOf: WorldMorph) ifFalse: [
		(refStream superclasses includesKey: #MorphicModel) ifTrue: [
			PopUpMenu notify: 'An object you have written has behavior in a MorphicModel.\The code for that behavior was not written out.\If you want to preserve the behavior, save this EToy\or save this world.' withCRs]].
