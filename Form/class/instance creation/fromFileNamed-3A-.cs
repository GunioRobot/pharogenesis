fromFileNamed: fileName
	"Read a Form or ColorForm from given file in any of four formats."

	^ self fromFile: (FileStream readOnlyFileNamed: fileName).
