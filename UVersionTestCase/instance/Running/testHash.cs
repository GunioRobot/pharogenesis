testHash
	typicalVersions do: [ :v |
		self should: [ v hash = v copy hash ] ].
	
	self should: [ (UVersion readFromString: '1.5a') hash = (UVersion readFromString: '1.5a') hash ].