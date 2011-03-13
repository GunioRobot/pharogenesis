saveWorldInFile
	"Save the world's submorphs, model, and stepList in a file.  "

	| fileName fileStream aClass |
	fileName _ FillInTheBlank request: 'File name for this morph?'.
	fileName isEmpty ifTrue: [^ self].  "abort"

	"Save only model, stepList, submorphs in this world"
	myWorld submorphsDo: [:m |
		m allMorphsDo: [:subM | subM prepareToBeSaved]].	"Amen"

	fileStream _ FileStream newFileNamed: fileName, '.morph'.
	aClass _ myWorld model ifNil: [nil] ifNotNil: [myWorld model class].
	fileStream fileOutClass: aClass andObject: myWorld.
