initializeProjectParameters
	projectParameters _ IdentityDictionary new.
	projectParameters at: #globalFlapsEnabledInProject put: true.
	^ projectParameters