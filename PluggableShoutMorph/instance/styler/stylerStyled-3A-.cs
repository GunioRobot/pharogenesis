stylerStyled: styledCopyOfText

	textMorph contents runs: styledCopyOfText runs .
	textMorph paragraph recomposeFrom: 1 to: textMorph contents size delta: 0.
	textMorph updateFromParagraph.
	selectionInterval 
		ifNotNil:[
			textMorph editor
				selectInvisiblyFrom: selectionInterval first to: selectionInterval last;
				storeSelectionInParagraph;
				setEmphasisHere].
	textMorph editor blinkParen.
	self scrollSelectionIntoView