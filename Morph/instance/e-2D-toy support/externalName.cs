externalName
	| n |
	(n _ self knownName) ifNotNil: [^ n].
	^ self innocuousName