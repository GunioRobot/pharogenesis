service
	^ self serviceOrNil ifNil: [ServiceCategory new id: self asSymbol]