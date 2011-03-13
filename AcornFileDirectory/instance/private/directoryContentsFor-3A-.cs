directoryContentsFor: fullPath 
	"Return a collection of directory entries for the files and directories in 
	the directory with the given path. See primLookupEntryIn:index: for 
	further details."
	"FileDirectory default directoryContentsFor: ''"

	| entries extraPath |
	entries := super directoryContentsFor: fullPath.
	fullPath isNullPath
		ifTrue: [
			"For Acorn we also make sure that at least the parent of the current dir 
			is added - sometimes this is in a filing system that has not been (or 
			cannot be) polled for disc root names"
			extraPath := self class default containingDirectory.
			"Only add the extra path if we haven't already got the root of the current dir in the list"
			entries detect: [:ent | extraPath fullName beginsWith: ent name] 
				ifNone: [entries := entries
								copyWith: (DirectoryEntry
										name: extraPath fullName
										creationTime: 0
										modificationTime: 0
										isDirectory: true
										fileSize: 0)]].
	^ entries
