addCustomEventFor: registrantClass named: aSymbol help: helpString targetMorphClass: targetClass
	| registration |
	registration _ self customEventsRegistry at: aSymbol ifAbsentPut: [ IdentityDictionary new ].
	registration at: registrantClass put: { helpString. targetClass }.
