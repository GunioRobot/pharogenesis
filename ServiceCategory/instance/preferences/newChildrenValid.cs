newChildrenValid
	| s |
	s := ServicePreferences valueOfPreference: self childrenPreferences.
	^ (s findTokens: ' ') allSatisfy: [:str | 
		str serviceOrNil 
			ifNil: [ServiceRegistry ifInteractiveDo: 
						[self inform: str, ' is not a valid service name']. 
					false]
			ifNotNil: [true]]