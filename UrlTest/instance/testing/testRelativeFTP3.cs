testRelativeFTP3
	
	baseUrl _ 'ftp://somewhere/some/dir/?query#fragment' asUrl.
	url _ baseUrl newFromRelativeText: 'http:xyz'.

	self assert: url toText = 'http://xyz/'.