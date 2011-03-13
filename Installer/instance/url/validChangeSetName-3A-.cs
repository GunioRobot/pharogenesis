validChangeSetName: aFileName
	" dots in the url confuses the changeset loader. I replace them with dashes"
 	self url ifNotNil: [ | asUrl |
		asUrl := Url absoluteFromText: aFileName.
		^String streamContents: [:stream |
			stream nextPutAll: (asUrl authority copyReplaceAll: '.' with: '-').
			asUrl path allButLastDo: [:each |
				stream
					nextPutAll: '/';
					nextPutAll: (each copyReplaceAll: '.' with: '-') ].
			stream
				nextPutAll: '/';
				nextPutAll: asUrl path last ] ].
	^aFileName