book: aBookMorph morphsToSort: morphList

	| innerBounds |
	book _ aBookMorph.
	pageHolder removeAllMorphs.
	pageHolder addAllMorphs: morphList.
	pageHolder extent: pageHolder width@pageHolder fullBounds height.
	innerBounds _ Rectangle merging: (morphList collect: [:m | m bounds]).
	pageHolder extent: innerBounds extent + pageHolder borderWidth + 6.