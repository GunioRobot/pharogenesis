createRequestFor: name in: aLoader
	| request |
	request _ super createRequestFor: name in: aLoader.
	request cachedName: cacheDir, name.
	^request