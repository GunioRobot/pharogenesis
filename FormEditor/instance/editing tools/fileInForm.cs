fileInForm
	"Ask the user for a file name and then recalls the Form in that file as 
	the current source Form (form). Does not change the tool."

	| fileName file |
	fileName _ self promptRequest: 'type a name for recalling a source Form . . . '.
	file _ FileStream oldFileNamed: fileName.
	file binary.
	form _ Form new readFrom: file.
	file close.
	tool _ previousTool.