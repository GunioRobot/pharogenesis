testRelativeHTTP
	
	baseUrl _ 'http://some.where/some/dir?query1#fragment1' asUrl.
	url _ baseUrl newFromRelativeText: '../another/dir/?query2#fragment2'.

	self assert: url toText =  'http://some.where/another/dir/?query2#fragment2'.