testIsUnsentMessage
	| class |
	class := classFactory newClass.
	class compile: 'messageNeverSentInTheSystemXXXXThisIsForTest ^self'.
	self assert: (navigator isUnsentMessage: class selectors anyOne)