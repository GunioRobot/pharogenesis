processRawMessage: aStringArray  fromConnection: connection
	| message |
	message _ UMessage fromStringArray: aStringArray.
	message applyToMultiServer: self forConnection: connection.
