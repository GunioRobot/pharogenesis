addReference: aReference
	| version |
	version := aReference versionReference version.
	version withAllDependenciesDo: [ :dependency |
		versions addLast: dependency.
		(repositories at: dependency ifAbsentPut: [ Set new ])
			addAll: aReference repositories ].
	model addVersion: version