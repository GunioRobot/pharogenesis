oldFileFrom: aDirectory withPattern: aPattern

	canTypeFileName _ false.
	pattern _ aPattern.
	^self makeFileMenuFor: aDirectory