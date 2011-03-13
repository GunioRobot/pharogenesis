specificMatch: aTree using: matchDict 
	^self selector = aTree selector
		and: [arguments = aTree arguments
		and: [block match: aTree block using: matchDict]]