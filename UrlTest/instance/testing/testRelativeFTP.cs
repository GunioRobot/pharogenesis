testRelativeFTP
	
	baseUrl _ 'ftp://somewhere/some/dir/?query#fragment' asUrl.
	url _ baseUrl newFromRelativeText: 'ftp://a.b'.

	self assert: url toText =  'ftp://a.b/'.