fileOutForm
	"Ask the user for a file name and then save the current source form 
	(form) under that name. Does not change the tool."

	| fileName file |
	fileName _ self promptRequest: 'type a name for saving the source Form . . . '.
	file _ FileStream newFileNamed: fileName.
	file binary.
	form writeOn: file.
	file close.
	tool _ previousTool.