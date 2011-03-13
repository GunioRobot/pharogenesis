fileInForm
	"Ask the user for a file name and then recalls the Form in that file as 
	the current source Form (form). Does not change the tool."

	| inName |
	inName _ self promptRequest: 'type a name for recalling a source Form . . . '.
	(FileDirectory isLegalFileName: inName) 
		ifTrue: [form _ Form readFrom: inName].
	tool _ previousTool