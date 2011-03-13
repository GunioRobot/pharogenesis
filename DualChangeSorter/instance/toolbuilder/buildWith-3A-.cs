buildWith: builder
	| windowSpec |
	leftCngSorter := ChangeSorter new myChangeSet: ChangeSet current.
	leftCngSorter parent: self.
	rightCngSorter := ChangeSorter new myChangeSet: 
			ChangeSorter secondaryChangeSet.
	rightCngSorter parent: self.

	windowSpec := builder pluggableWindowSpec new.
	windowSpec model: self.
	windowSpec label: 'Change Sorter'.
	windowSpec children: OrderedCollection new.
	leftCngSorter buildWith: builder in: windowSpec rect: (0@0 extent: 0.5@1).
	rightCngSorter buildWith: builder in: windowSpec rect: (0.5@0 extent: 0.5@1).
	^builder build: windowSpec
