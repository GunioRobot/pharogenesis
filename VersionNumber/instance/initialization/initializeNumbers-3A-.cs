initializeNumbers: aCollection

	aCollection do: [ :ea | 
		ea <= 0 ifTrue: 
			[^self error: 'VersionNumbers cannot contain zero or negative numbers']].

	numbers := aCollection asArray