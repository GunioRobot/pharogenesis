fromUser
	"Answer an instance of me obtained by requesting the user to type a string."
	"Text fromUser"

	^ self fromString:
		(FillInTheBlank request: 'Enter text followed by carriage return')
