temporaries
	" [ 'Use' (variable)* '.' ]"
	| vars theActualText |
	(self matchToken: #'Use') ifFalse: 
		["no temps"
		doitFlag ifTrue: [requestor
				ifNil: [tempsMark _ 1]
				ifNotNil: [tempsMark _ requestor selectionInterval first].
			^ #()].
		tempsMark _ prevEnd+1.
		tempsMark > 0 ifTrue:
			[theActualText _ source contents.
			[tempsMark < theActualText size and: [(theActualText at: tempsMark) isSeparator]]
				whileTrue: [tempsMark _ tempsMark + 1]].
			^ #()].
	vars _ OrderedCollection new.
	[hereType == #word]
		whileTrue: [vars addLast: (encoder bindTemp: self advance)].
	(self match: #period) ifTrue: 
		[tempsMark _ prevMark.
		^ vars].
	^ self expected: 'Period'