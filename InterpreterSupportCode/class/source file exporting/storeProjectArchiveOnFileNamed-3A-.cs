storeProjectArchiveOnFileNamed: fileName
	"Store into this image's folder a StuffIt archive file containing the CodeWarrier project files for the virtual machine. You will need to use a StuffIt unpacking utility such as StuffIt Expander to unpack the file. The result will be two project files for CodeWarrier, version 8."

	| f |
	f _ (FileStream newFileNamed: fileName) binary.
	self macArchiveBinaryFile do: [:byte | f nextPut: byte].
	f close.
	FileDirectory default setMacFileNamed: fileName type: 'SITD' creator: 'SIT!'.
