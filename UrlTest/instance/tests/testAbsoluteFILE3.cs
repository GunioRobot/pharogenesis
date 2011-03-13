testAbsoluteFILE3
	"Just a few selected tests for FileUrl, not complete by any means."


	{'file:'. 'file:/'. 'file://'} do: [:s |
	 	url _ FileUrl absoluteFromText: s.
		self assert: (url asString = 'file:///').
		self assert: (url host = '').
		self assert: url isAbsolute].
	
	url _ FileUrl absoluteFromText: 'file://localhost/dir/file.txt'.
	self assert: (url asString = 'file://localhost/dir/file.txt').
	self assert: (url host = 'localhost').
	
	url _ FileUrl absoluteFromText: 'file://localhost/dir/file.txt'.
	self assert: (url asString = 'file://localhost/dir/file.txt').
	self assert: (url host = 'localhost').
	self assert: url isAbsolute.
	
	url _ FileUrl absoluteFromText: 'file:///dir/file.txt'.
	self assert: (url asString = 'file:///dir/file.txt').
	self assert: (url host = '').
	self assert: url isAbsolute.
	
	url _ FileUrl absoluteFromText: '/dir/file.txt'.
	self assert: (url asString = 'file:///dir/file.txt').
	self assert: url isAbsolute.
	
	url _ FileUrl absoluteFromText: 'dir/file.txt'.
	self assert: (url asString = 'file:///dir/file.txt').
	self deny: url isAbsolute.
	
	url _ FileUrl absoluteFromText: 'c:/dir/file.txt'.
	self assert: (url asString = 'file:///c%3A/dir/file.txt').
	self assert: url isAbsolute.
	
	"Only a drive letter doesn't refer to a directory."
	url _ FileUrl absoluteFromText: 'c:'.
	self assert: (url asString = 'file:///c%3A/').
	self assert: url isAbsolute.
	
	url _ FileUrl absoluteFromText: 'c:/'.
	self assert: (url asString = 'file:///c%3A/').
	self assert: url isAbsolute