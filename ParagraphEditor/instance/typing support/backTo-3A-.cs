backTo: startIndex
	"During typing, backspace to startIndex.  Deleted characters fall into three
	 clusters, from left to right in the text: (1) preexisting characters that were
	 backed over; (2) newly typed characters that were backed over (excluding
	 typeahead, which never even appears); (3) preexisting characters that
	 were highlighted before typing began.  If typing has not yet been opened,
	 open it and watch for the first and third cluster.  If typing has been opened,
	 watch for the first and second cluster.  Save characters from the first and third
	 cluster in UndoSelection.  Tally characters from the first cluster in UndoMessage's parameter.
	 Delete all the clusters.  Do not alter Undoer or UndoInterval (except via
	 openTypeIn).  The code is shorter than the comment."

	| saveLimit newBackovers |
	saveLimit := beginTypeInBlock == nil
		ifTrue: [self openTypeIn. UndoSelection := self nullText. self stopIndex]
		ifFalse: [self startOfTyping].
	self setMark: startIndex.
	startIndex < saveLimit ifTrue:
		[newBackovers := self startOfTyping - startIndex.
		beginTypeInBlock := self startIndex.
		UndoSelection replaceFrom: 1 to: 0 with:
			(paragraph text copyFrom: startIndex to: saveLimit - 1).
		UndoMessage argument: (UndoMessage argument ifNil: [1]) + newBackovers].
	self zapSelectionWith: self nullText.
	self unselect