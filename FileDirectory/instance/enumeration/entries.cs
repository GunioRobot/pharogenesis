entries
	"Return a collection of directory entries for the files and directories in this directory. Each entry is a five-element array: (<name><creationTime><modificationTime><dirFlag><fileSize>). See primLookupEntryIn:index: for further details."
	"FileDirectory default entries"

	^ self directoryContentsFor: pathName
