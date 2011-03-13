sortedPackages
	^universe packages asSortedCollection: [ :p1 :p2 |
		p1 name < p2 name or: [
			p1 name = p2 name and: [ p1 version < p2 version ] ] ].
	