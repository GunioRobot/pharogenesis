testIsUnsentMessagesAnswerMethodReferences
	| class otherClass methReference |
	class := classFactory newClass.
	class compile: 'messageNeverSentInTheSystemXXXXThisIsForTest ^self'.
	class compile: 'sentMessage'.
	otherClass := classFactory newClass.
	otherClass compile: 'printString self sentMessage'.
	otherClass compile: 'otherMessageNeverSentInTheSystemXXXXThisIsForTest ^self'.
	methReference := (navigator unsentMessagesInCategory: classFactory defaultCategory) anyOne.
	self assert: (methReference isKindOf: MethodReference)