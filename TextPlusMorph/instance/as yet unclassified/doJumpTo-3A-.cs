doJumpTo: aString

	| myStart myStop |
	myStart _ myStop _ nil.
	text runs withStartStopAndValueDo: [:start :stop :attributes |
		attributes do: [:att |
			((att isMemberOf: TextPlusJumpEnd) and: [att jumpLabel = aString]) ifTrue: [
				myStart 
					ifNil: [myStart _ start. myStop _ stop] 
					ifNotNil: [myStart _ myStart min: start. myStop _ myStop max: stop].
			]
		]
	].
	myStart ifNil: [^self].

	self editor selectFrom: myStart to: myStop.
	ignoreNextUp _ true.
	self changed.
	self scrollSelectionToTop.
