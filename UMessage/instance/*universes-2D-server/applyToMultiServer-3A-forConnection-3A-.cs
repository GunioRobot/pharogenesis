applyToMultiServer: server  forConnection: connection
	connection nextPut: (UMError description: 'message inappropriate for multi-server') asStringArray