newFileFrom: aDirectory withPattern: aPattern

	canTypeFileName _ true.
	pattern _ aPattern.
	^self makeFileMenuFor: aDirectory