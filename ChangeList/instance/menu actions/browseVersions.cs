browseVersions
	| change class browser |
	listIndex = 0
		ifTrue: [^ nil ].
	change _ changeList at: listIndex.
	((class _ change methodClass) notNil
			and: [class includesSelector: change methodSelector])
		ifFalse: [ ^nil ].
	browser _ super browseVersions.
	browser ifNotNil: [ browser addedChangeRecord: change ].
	^browser