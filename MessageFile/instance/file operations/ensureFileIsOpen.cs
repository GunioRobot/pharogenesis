ensureFileIsOpen
	"Make sure that my file is open. The file is automatically closed on snapshots."

	file
		ifNil: [file _ FileStream fileNamed: filename]
		ifNotNil: [file ensureOpen].
