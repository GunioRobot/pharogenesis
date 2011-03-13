versionReference
	| versions |
	versions := self 
		findVersions: [ :each | self matchesVersionReference: each ].
	versions isEmpty
		ifTrue: [ self error: 'No versions for package ' , self packageName printString , ' found.' ].
	^ versions last