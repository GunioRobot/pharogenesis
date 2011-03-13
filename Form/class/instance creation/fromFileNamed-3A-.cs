fromFileNamed: fileName 
	"Read a Form or ColorForm from the given file."
	| file form |
	file := (FileStream readOnlyFileNamed: fileName) binary.
	form := self fromBinaryStream: file.
	Project current resourceManager addResource: form url: (FileDirectory urlForFileNamed: file name) asString.
	file close.
	^ form