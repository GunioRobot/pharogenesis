testDefaultDirRoundtrip
	| defaultDir defaultURI uriDir |
	defaultDir := FileDirectory default.
	defaultURI := defaultDir uri.
	uriDir := FileDirectory uri: defaultURI.
	self should: [defaultDir fullName = uriDir fullName]