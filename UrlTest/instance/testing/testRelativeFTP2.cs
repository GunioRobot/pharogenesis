testRelativeFTP2
	
	baseUrl _ 'ftp://somewhere/some/dir/?query#fragment' asUrl.
	url _ baseUrl newFromRelativeText: 'ftp:xyz'.


	self assert: url toText =  'ftp://somewhere/some/dir/xyz'.