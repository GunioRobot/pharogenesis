deleteTemporaryDirectory
	"
	ArchiveViewer deleteTemporaryDirectory
	"

	| dir |
	(dir _ self temporaryDirectory) exists ifTrue: [ dir recursiveDelete ].