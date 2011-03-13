preLoadFromArchive: aZipArchive cacheName: aFileName
	"Load the resources from the given zip archive"
	| orig nameMap resMap loc stream |
	self class reloadCachedResources.
	resMap := Dictionary new.
	nameMap := Dictionary new.
	unloaded do:[:locator|
		locator localFileName: nil.
		nameMap at: locator urlString put: locator.
		resMap at: locator urlString put: (resourceMap at: locator)].

	aZipArchive members do:[:entry|
		stream := nil.
		orig := resMap at: (self convertMapNameForBackwardcompatibilityFrom: entry fileName ) ifAbsent:[nil].
		loc := nameMap at: (self convertMapNameForBackwardcompatibilityFrom: entry fileName ) ifAbsent:[nil].
		"note: orig and loc may be nil for non-resource members"
		(orig notNil and:[loc notNil]) ifTrue:[
			stream := entry contentStream.
			self installResource: orig from: stream locator: loc.
			stream reset.
			aFileName 
				ifNil:[self class cacheResource: loc urlString stream: stream]
				ifNotNil:[self class cacheResource: loc urlString inArchive: aFileName]].
	].