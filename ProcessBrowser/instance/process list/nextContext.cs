nextContext
	| initialProcessIndex initialStackIndex found |
	searchString isEmpty ifTrue: [ ^false ].
	initialProcessIndex _ self processListIndex.
	initialStackIndex _ self stackListIndex.
	found _ false.
	initialProcessIndex
		to: self processList size
		do: [:pi | found
				ifFalse: [self processListIndex: pi.
					self stackNameList
						withIndexDo: [:name :si | (found not
									and: [pi ~= initialProcessIndex
											or: [si > initialStackIndex]])
								ifTrue: [(name includesSubString: searchString)
										ifTrue: [self stackListIndex: si.
											found _ true]]]]].
	found
		ifFalse: [self processListIndex: initialProcessIndex.
			self stackListIndex: initialStackIndex].
	^ found