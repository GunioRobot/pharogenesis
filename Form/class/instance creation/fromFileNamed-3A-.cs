fromFileNamed: fileName
	"Read a Form or ColorForm from the given file."

	| file form |
	file _ (FileStream readOnlyFileNamed: fileName) binary.
	form _ self fromBinaryStream: file.
	file close.
	^ form
