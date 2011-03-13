specificMatch: aTree using: matchDict 
	^(variable match: aTree variable using: matchDict)
		and: [value match: aTree value using: matchDict]