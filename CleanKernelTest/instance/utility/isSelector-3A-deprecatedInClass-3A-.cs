isSelector: aSymbol deprecatedInClass: aClassSymbol 

	| cls |
	cls _ Smalltalk
				at: aClassSymbol
				ifAbsent: [^ false].
	^ (cls >> aSymbol) literals includesAllOf: #(deprecated:)