moveChangedCommentToFile: aFileStream numbered: fileIndex 
	"If the comment is in the changes file, then move it to a new file."

	(globalComment ~~ nil and: [globalComment sourceFileNumber > 1]) ifTrue: 
		[self fileOutCommentOn: aFileStream moveSource: true toFile: fileIndex]