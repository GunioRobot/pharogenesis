externalPreferences
	| p |
	p := ServicePreferences valueOfPreference: self childrenPreferences ifAbsent: [''].
	^ (p findTokens: ' ') collect: [:e | e service]