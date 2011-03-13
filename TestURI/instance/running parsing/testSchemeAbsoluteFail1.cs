testSchemeAbsoluteFail1
	self should: [URI fromString: 'http:'] raise: IllegalURIException