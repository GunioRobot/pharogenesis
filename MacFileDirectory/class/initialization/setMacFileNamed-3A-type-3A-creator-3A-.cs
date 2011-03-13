setMacFileNamed: fileName type: typeString creator: creatorString
	"Set the Macintosh file type and creator info for the file with the given name. Fails if the file does not exist or if the type and creator type arguments are not strings of length 4."
	"Mac specific; noop on other platforms."

 	<primitive: 169>
	self primitiveFailed.