confirm: queryString 
	| choice |
	[true]
		whileTrue: 
			[choice := self request: queryString , '
Please type yes or no followed by return'.
			choice first asUppercase = $Y ifTrue: [^ true].
			choice first asUppercase = $N ifTrue: [^ false]]