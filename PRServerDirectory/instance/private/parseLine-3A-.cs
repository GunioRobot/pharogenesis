parseLine: aString 
"private - parse a line from a server response"
	| tokens |
	tokens := aString findTokens: '|'.
	""
	^ tokens first = 'D'
		ifTrue: [""
			DirectoryEntry
				name: tokens second
				creationTime: 0
				modificationTime: 0
				isDirectory: true
				fileSize: 0]
		ifFalse: [""
			DirectoryEntry
				name: tokens second
				creationTime: tokens third asInteger
				modificationTime: tokens fourth asInteger
				isDirectory: false
				fileSize: tokens fifth asInteger]