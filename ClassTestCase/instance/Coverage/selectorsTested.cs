selectorsTested
	| literals |
	literals _ Set new.
	self class
		selectorsAndMethodsDo: [ :s :m | (s beginsWith: 'test')
			ifTrue: [ literals addAll: (m literals select: [ :l | l isSymbol and: [l first isLowercase]]) ] ].
	^ literals