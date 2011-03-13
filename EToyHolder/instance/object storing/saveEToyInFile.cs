saveEToyInFile
	| fileName fileStream aClass aWorld  |
	aWorld _ eToyPalette world.
	fileName _ FillInTheBlank request: 'File name for this EToy?'.
	fileName isEmpty ifTrue: [^ self].  "abort"

	aWorld presenter init2.	"backward compatability, add property  #eToyControl"
	aWorld abandonAllHalos.
	fileStream _ FileStream newFileNamed: fileName, '.sqo'.
	aClass _ self class.
	aClass == EToyHolder ifTrue: [aClass _ nil].	"reading system has it already"
	fileStream fileOutClass: aClass 
			andObject: self
			blocking: self whoToBlock.
	self title: fileName.
	"aController _ aWorld standardSystemController.
	aController ifNotNil:
		[aController view relabel: fileName]."