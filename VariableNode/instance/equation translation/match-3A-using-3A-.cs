match: aTree using: matchDict 
	(key isMemberOf: Symbol)
		ifTrue: [(matchDict at: key
				ifAbsent: 
					[matchDict at: key put: aTree.
					^true])
				match: aTree using: Dictionary new]
		ifFalse: [^name = aTree name]