initSymbols: aClass
	| nTemps namedTemps |
	constructor method: method class: aClass literals: method literals.
	constTable _ constructor codeConstants.
	instVars _ Array new: aClass instSize.
	nTemps _ method numTemps.
	namedTemps _ tempVars ifNil: [method tempNames].
	tempVars _ (1 to: nTemps) collect:
				[:i | i <= namedTemps size
					ifTrue: [constructor codeTemp: i - 1 named: (namedTemps at: i)]
					ifFalse: [constructor codeTemp: i - 1]]