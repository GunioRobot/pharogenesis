temporaries
	" [ '|' (variable)* '|' ] "
	| vars |
	(self match: #verticalBar) ifFalse:	"no temps"
		[tempsMark _ hereMark.
		^ #()].
	vars _ OrderedCollection new.
	[hereType == #word]
		whileTrue: [vars addLast: (encoder bindTemp: self advance)].
	(self match: #verticalBar) ifTrue:
		[tempsMark _ prevMark.
		^ vars].
	^self expected: 'Vertical bar'