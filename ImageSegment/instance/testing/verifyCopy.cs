verifyCopy

	| copyOfRoots matchDict |
	copyOfRoots _ self segmentCopy.
	matchDict _ IdentityDictionary new.
	arrayOfRoots with: copyOfRoots do:
		[:r :c | self verify: r matches: c knowing: matchDict]