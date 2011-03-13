tallySelfSendsFor: selector 
	"Logically, we do the following test: 
		(self neverRequiredSelectors includes: selector) ifTrue: [^ self].
	However, since this test alone was reponsible for 2.8% of the execution time,
	we replace it with the following:"
	selector == nr1 ifTrue:[^ self].
	selector == nr2 ifTrue:[^ self].
	selector == nr3 ifTrue:[^ self].
	selector == nr4 ifTrue:[^ self].
	selector == nr5 ifTrue:[^ self].
	selector == #class ifTrue:[^ self].
	self addSelfSentSelector: selector.