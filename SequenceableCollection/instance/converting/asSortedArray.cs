asSortedArray
	1 to: (self size - 1) do:
		[:i | (self at: i) >= (self at: (i+1)) ifTrue: 
				[self flag: #developmentNote.
				"The optimization used here is, I HOPE, really an optimization.  The idea is that most collections processed will already be sorted, so we don't bother going through the double-transformation of the next line until we're sure that it is necessary.  On the other hand, the test for need-to-sort is itself not free.  sw"
				^ self asSortedCollection asArray]].
	^ self asArray