exists
"Answer whether the directory exists"

	| result |
	result _ self primLookupEntryIn: pathName asVmPathName index: 1.
	^ result ~= #badDirectoryPath
