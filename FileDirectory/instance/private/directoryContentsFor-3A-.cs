directoryContentsFor: fullPath
	"Return a collection of directory entries for the files and directories in the directory with the given path. See primLookupEntryIn:index: for further details."
	"FileDirectory default directoryContentsFor: ''"

	| entries index done entryArray f |
	entries := OrderedCollection new: 200.
	index := 1.
	done := false.
	f := fullPath asVmPathName.
	[done] whileFalse: [
		entryArray := self primLookupEntryIn: f index: index.
		#badDirectoryPath = entryArray ifTrue: [
			^(InvalidDirectoryError pathName: pathName asSqueakPathName) signal].
		entryArray == nil
			ifTrue: [done := true]
			ifFalse: [entries addLast: (DirectoryEntry fromArray: entryArray)].
		index := index + 1].

	^ entries asArray collect: [:s | s convertFromSystemName].
