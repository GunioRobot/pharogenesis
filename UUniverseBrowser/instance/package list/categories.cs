categories
	^((self sortedPackages collect: [ :p | p category])
		asSet
		asSortedCollection: [ :p1 :p2 | p1 asString < p2 asString])
		asArray