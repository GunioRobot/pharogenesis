addCacheLocation: aString for: urlString
	| locations |
	locations _ CachedResources at: urlString ifAbsentPut: [#()].
	(locations includes: aString)
		ifFalse: [CachedResources at: urlString put: ({aString} , locations)]