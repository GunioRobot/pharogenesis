prefServices
	| s |
	s := ServicePreferences valueOfPreference: self childrenPreferences.
	^ (s findTokens: ' ') collect: [:str | str service]