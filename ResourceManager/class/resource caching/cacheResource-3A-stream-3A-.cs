cacheResource: urlString stream: aStream
	| fd localName file buf |
	HTTPClient shouldUsePluginAPI ifTrue:[^self]. "use browser cache"
	(self resourceCache at: urlString ifAbsent:[#()]) size > 0 
		ifTrue:[^self]. "don't waste space"
	fd _ Project squeakletDirectory.
	localName _ fd nextNameFor: 'resource' extension:'cache'.
	file _ fd forceNewFileNamed: localName.
	buf _ ByteArray new: 10000.
	aStream binary.
	file binary.
	[aStream atEnd] whileFalse:[
		buf _ aStream next: buf size into: buf.
		file nextPutAll: buf.
	].
	file close.
	"update cache"
	file _ [fd oldFileNamed: self resourceCacheName] 
			on: FileDoesNotExistException
			do:[:ex| fd forceNewFileNamed: self resourceCacheName].
	file setToEnd.
	file nextPutAll: urlString; cr.
	file nextPutAll: localName; cr.
	file close.
	self addCacheLocation: localName for: urlString.
	aStream position: 0.
