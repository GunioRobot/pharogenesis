retrieveContentsFor: url
	| request |
	request _ PluginHTTPRequest for: url in: self.
	self addRequest: request.
	^request contents