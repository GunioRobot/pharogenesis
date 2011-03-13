webFindUrlToDownload

	self class webSearchPath do: [ :pathSpec | 
		| potentialUrl readPathSpec  |
	
		readPathSpec := pathSpec readStream.
		potentialUrl := (readPathSpec upTo: $*), package, (readPathSpec upToEnd ifNil: [ '' ]).
	
		pageDataStream := self urlGet: potentialUrl.
		
		pageDataStream notNil ifTrue: [ ^potentialUrl ]
	].

	^nil
