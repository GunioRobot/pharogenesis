deleteTemporaryDirectory
	"
	ArchiveViewer deleteTemporaryDirectory
	"

	| dir |
	(dir := self temporaryDirectory) exists ifTrue: [ dir recursiveDelete ].