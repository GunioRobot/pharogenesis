putCommentOnFile: aFileStream numbered: sourceIndex moveSource: moveSource 
	"Store the comment about the class onto file, aFileStream."

	| newRemoteString |
	globalComment ~~ nil
		ifTrue: 
			[aFileStream cr.
			newRemoteString _ 
				RemoteString
						newString: globalComment string
						onFileNumber: sourceIndex
						toFile: aFileStream.
			moveSource ifTrue: [globalComment _ newRemoteString]]