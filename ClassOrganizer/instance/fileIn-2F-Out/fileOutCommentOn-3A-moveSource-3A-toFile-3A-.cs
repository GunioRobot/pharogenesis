fileOutCommentOn: aFileStream moveSource: moveSource toFile: fileIndex
	"Copy the class comment to aFileStream.  If moveSource is true (as in compressChanges or compressSources, then update globalComment to point to the new file."
	| fileComment |
	globalComment ifNotNil: 
			[aFileStream cr.
			fileComment _ RemoteString newString: globalComment text
							onFileNumber: fileIndex toFile: aFileStream.
			moveSource ifTrue: [globalComment _ fileComment]]