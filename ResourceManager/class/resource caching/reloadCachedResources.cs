reloadCachedResources	"ResourceManager reloadCachedResources"
	"Reload cached resources from the disk"
	| fd files stream url localName storeBack archiveName |
	CachedResources _ Dictionary new.
	LocalizedExternalResources _ nil.
	fd _ Project squeakletDirectory.
	files _ fd fileNames asSet.
	stream _ [fd readOnlyFileNamed: self resourceCacheName]
				on: FileDoesNotExistException 
				do:[:ex| fd forceNewFileNamed: self resourceCacheName].
	stream size < 50000 ifTrue:[stream _ ReadStream on: stream contentsOfEntireFile].
	storeBack _ false.
	[stream atEnd] whileFalse:[
		url _ stream upTo: Character cr.	
		localName _ stream upTo: Character cr.
		(localName beginsWith: 'zip://') ifTrue:[
			archiveName _ localName copyFrom: 7 to: localName size.
			(files includes: archiveName) 
				ifTrue:[self addCacheLocation: localName for: url]
				ifFalse:[storeBack _ true].
		] ifFalse:[
			(files includes: localName) 
				ifTrue:[self addCacheLocation: localName for: url]
				ifFalse:[storeBack _ true]
		].
	].
	stream close.
	storeBack ifTrue:[
		stream _ fd forceNewFileNamed: self resourceCacheName.
		CachedResources keysAndValuesDo:[:urlString :cacheLocs|
			cacheLocs do:[:cacheLoc|
				stream nextPutAll: urlString; cr.
				stream nextPutAll: cacheLoc; cr].
		].
		stream close.
	].