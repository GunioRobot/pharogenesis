updateDisplayContents 
	"Refer to the comment in StringHolderView|updateDisplayContents."

	| contents |
	contents _ model contents.
	displayContents string ~= contents
		ifTrue: 
			[displayContents _
				(contents asText makeSelectorBoldIn: model selectedClassOrMetaClass) asParagraph.
			self positionDisplayContents.
			self controller changeParagraph: displayContents.
			self displayView.
			self highlightPC]