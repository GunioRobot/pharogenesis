chooseInstVarAlphabeticallyThenDo: aBlock
	| allVars index |
	"Put up a menu of all the instance variables in the receiver, presented in alphabetical order, and when the user chooses one, evaluate aBlock with the chosen variable as its parameter."

	allVars _ self allInstVarNames asSortedArray.
	allVars isEmpty ifTrue: [^ self inform: 'There are no
instance variables'].

	index _ (UIManager default chooseFrom: allVars lines: #() title: 'Instance variables in
', self name).
	index = 0 ifTrue: [^ self].
	aBlock value: (allVars at: index)