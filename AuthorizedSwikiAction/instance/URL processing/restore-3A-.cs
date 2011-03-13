restore: nameOfSwiki
	"Read all files in the directory 'nameOfSwiki'.  Reconstruct the url map."

	| fName |
	super restore: nameOfSwiki.
	fName _ ServerAction serverDirectory, name, (ServerAction pathSeparator), 
				'authorizer'.
	authorizer _ (FileStream oldFileNamed: fName) fileInObjectAndCode.
