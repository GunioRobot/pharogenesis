exchangeWith: prior
	"If the prior selection is non-overlapping and legal, exchange the text of
	 it with the current selection and leave the currently selected text selected
	 in the location of the prior selection (or leave a caret after a non-caret if it was
	 exchanged with a caret).  If both selections are carets, flash & do nothing.
	 Don't affect the paste buffer.  Undoer: itself; Redoer: Undoer."

	| start stop before selection priorSelection delta altInterval |
	start := self startIndex.
	stop := self stopIndex - 1.
	((prior first <= prior last) | (start <= stop) "Something to exchange" and:
			[self isDisjointFrom: prior])
		ifTrue:
			[before := prior last < start.
			selection := self selection.
			priorSelection := paragraph text copyFrom: prior first to: prior last.

			delta := before ifTrue: [0] ifFalse: [priorSelection size - selection size].
			self zapSelectionWith: priorSelection.
			self selectFrom: prior first + delta to: prior last + delta.

			delta := before ifTrue: [stop - prior last] ifFalse: [start - prior first].
			self zapSelectionWith: selection.
			altInterval := prior first + delta to: prior last + delta.
			self undoer: #exchangeWith: with: altInterval.
			"If one was a caret, make it otherInterval & leave the caret after the other"
			prior first > prior last ifTrue: [self selectAt: UndoInterval last + 1].
			otherInterval := start > stop
				ifTrue: [self selectAt: altInterval last + 1. UndoInterval]
				ifFalse: [altInterval]]
		ifFalse:
			[self flash]