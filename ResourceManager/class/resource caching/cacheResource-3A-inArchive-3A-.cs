cacheResource: urlString inArchive: archiveName
	"Remember the given url as residing in the given archive"
	| fd file fullName |
	fullName _ 'zip://', archiveName.
	((self resourceCache at: urlString ifAbsent:[#()]) 
		anySatisfy:[:cache| cache = fullName]) ifTrue:[^self]. "don't cache twice"
	fd _ Project squeakletDirectory.
	"update cache"
	file _ [fd oldFileNamed: self resourceCacheName] 
			on: FileDoesNotExistException
			do:[:ex| fd forceNewFileNamed: self resourceCacheName].
	file setToEnd.
	file nextPutAll: urlString; cr.
	file nextPutAll: fullName; cr.
	file close.
	self addCacheLocation: fullName for: urlString.