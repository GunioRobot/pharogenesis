storeStuffitArchive: archiveData onFileNamed: fileName
	"Store the given binary data as a file with the type and creator of a Stuff archive file. You will need to use a StuffIt unpacking utility such as StuffIt Expander to unpack the file."

	| f |
	f _ (FileStream newFileNamed: fileName) binary.
	archiveData do: [:byte | f nextPut: byte].
	f close.
	FileDirectory default setMacFileNamed: fileName type: 'SITD' creator: 'SIT!'.
