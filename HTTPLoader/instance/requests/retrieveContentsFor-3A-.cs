retrieveContentsFor: url
	| request |
	request _ self class httpRequestClass for: url in: self.
	self addRequest: request.
	^request contents