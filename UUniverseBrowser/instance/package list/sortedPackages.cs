sortedPackages
	| packages |
	packages := Set new.
	packages addAll: universe packages.
	packages addAll: configuration installedPackages.
	
	^packages asSortedCollection: [ :p1 :p2 |
		p1 name < p2 name or: [
			p1 name = p2 name and: [ p1 version < p2 version ] ] ].
	