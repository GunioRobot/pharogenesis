temporaries
	" [ '|' (variable)* '|' ]"
	| vars theActualText |
	(self match: #verticalBar) ifFalse: 
		["no temps"
		doitFlag ifTrue: [requestor
				ifNil: [tempsMark _ 1]
				ifNotNil: [tempsMark _ requestor selectionInterval first].
			^ #()].
		tempsMark _ (prevEnd ifNil: [0]) + 1.
		tempsMark _ hereMark	"formerly --> prevMark + prevToken".

		tempsMark > 0 ifTrue:
			[theActualText _ source contents.
			[tempsMark < theActualText size and: [(theActualText at: tempsMark) isSeparator]]
				whileTrue: [tempsMark _ tempsMark + 1]].
			^ #()].
	vars _ OrderedCollection new.
	[hereType == #word]
		whileTrue: [vars addLast: (encoder bindTemp: self advance)].
	(self match: #verticalBar) ifTrue: 
		[tempsMark _ prevMark.
		^ vars].
	^ self expected: 'Vertical bar'