example
	"FileDoesNotExistException example"

	| result |
	result _ [(StandardFileStream readOnlyFileNamed: 'error42.log') contentsOfEntireFile]
		on: FileDoesNotExistException
		do: [:ex | 'No error log'].
	Transcript show: result; cr