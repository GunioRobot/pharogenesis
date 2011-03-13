install: aFileName from: stream

| ext installSelector |
	 
	self log: 'installing...'.
 
	ext := aFileName copyAfterLast: $..
	installSelector := ('install', ext asUppercase, ':from:') asSymbol.
	
	self withAnswersDo:	[
		(self respondsTo: installSelector)
			ifTrue: [ self perform: installSelector with: aFileName with: stream ]
			ifFalse: [ self installDefault: aFileName from: stream ].
	]. 

	self log: '.done'
 