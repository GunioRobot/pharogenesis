sortPages: evt

	| sorter |
	sorter _ BookPageSorterMorph new forBook: self.
	sorter pageHolder cursor: (pages indexOf: currentPage ifAbsent: [0]).
	evt == nil
		ifTrue: [self world addMorphFront: sorter]
		ifFalse: [evt hand attachMorph: sorter].
