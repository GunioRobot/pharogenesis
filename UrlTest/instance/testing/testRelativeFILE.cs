testRelativeFILE
	
	| url2 |
	baseUrl _ 'file:/some/dir#fragment1' asUrl.
	url _ baseUrl newFromRelativeText: 'file:../another/dir/#fragment2'.
	self assert: url toText =  'file:///another/dir/#fragment2'.
	
	url _ FileUrl absoluteFromText: 'file://localhost/dir/dir2/file.txt'.
	url2 _ FileUrl absoluteFromText: 'file://hostname/flip/file.txt'.
	url2 privateInitializeFromText: '../file2.txt' relativeTo: url.
	self assert: (url2 asString = 'file://localhost/dir/file2.txt').
	self assert: (url2 host = 'localhost').
	self assert: url2 isAbsolute.
	
	url _ FileUrl absoluteFromText: 'file://localhost/dir/dir2/file.txt'.
	url2 _ FileUrl absoluteFromText: 'flip/file.txt'.
	self deny: url2 isAbsolute.
	url2 privateInitializeFromText: '.././flip/file.txt' relativeTo: url.
	self assert: (url2 asString = 'file://localhost/dir/flip/file.txt').
	self assert: (url2 host = 'localhost').
	self assert: url2 isAbsolute.
	
