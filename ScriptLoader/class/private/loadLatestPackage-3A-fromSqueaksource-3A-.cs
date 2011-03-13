loadLatestPackage: aString fromSqueaksource: aDirectoryName
	" self loadLatestPackage: 'ScriptLoader' fromSqueaksource: 'Pharo' "

	self loadLatestPackage: aString from: 'http://www.squeaksource.com/', aDirectoryName
	