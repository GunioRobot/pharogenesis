name: aString actionBlock: aBlock cancelBlock: altBlock

	theName _ aString.
	actionBlock _ aBlock.
	cancelBlock _ altBlock.
	theNameMorph contentsWrapped: theName.
	theNameMorph editor selectAll.