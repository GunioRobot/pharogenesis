fileOutCommentOn: aFileStream moveSource: moveSource toFile: fileIndex
	"Copy the class comment to aFileStream.  If moveSource is true (as in compressChanges or compressSources, then update classComment to point to the new file."
	| fileComment |
	classComment ifNotNil: 
			[aFileStream cr.
			fileComment _ RemoteString newString: classComment text
							onFileNumber: fileIndex toFile: aFileStream.
			moveSource ifTrue: [classComment _ fileComment]]