applyToServer: server  forConnection: connection
self inspect.
	connection nextPut: (UMError description: 'message inappropriate for server') asStringArray