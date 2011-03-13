restore: nameOfSwiki
	"Read all files in the directory 'nameOfSwiki'.  Reconstruct the url map."

	| fName |
	super restore: nameOfSwiki.
	fName _ ServerAction serverDirectory, name, (ServerAction pathSeparator), 
				'authorizer'.
	(FileDirectory new fileExists: fName) ifTrue: [
		authorizer _ (FileStream readOnlyFileNamed: fName) fileInObjectAndCode].
