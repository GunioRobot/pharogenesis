tempNames 
	| tempNodes |
	tempNodes _ SortedCollection sortBlock: [:n1 :n2 | n1 code <= n2 code].
	scopeTable associationsDo:
		[:assn | (assn value isTemp and:
				[assn value isMemberOf: VariableNode]) "no remote temps"
			ifTrue: [tempNodes add: assn value]].
	^tempNodes collect: [:node | node key]