directoryContentsFor: fullPath
	"Return a collection of directory entries for the files and directories in the directory with the given path. See primLookupEntryIn:index: for further details."
	"FileDirectory default directoryContentsFor: ''"

	| entries index done entryArray |
	entries _ OrderedCollection new: 200.
	index _ 1.
	done _ false.
	[done] whileFalse: [
		entryArray _ self primLookupEntryIn: fullPath index: index.
		#badDirectoryPath = entryArray ifTrue: [^ OrderedCollection new].
		entryArray == nil
			ifTrue: [done _ true]
			ifFalse: [entries addLast: (DirectoryEntry fromArray: entryArray)].
		index _ index + 1].

	^ entries asArray
