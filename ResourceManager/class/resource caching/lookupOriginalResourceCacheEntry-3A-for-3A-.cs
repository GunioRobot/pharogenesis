lookupOriginalResourceCacheEntry: resourceFileName for: resourceUrl
	"See if we have cached the resource described by the given url in an earlier version of the same project on the same server. In that case we don't need to upload it again but rather link to it."
	| candidates resourceBase resourceMatch matchingUrls |
	
	CachedResources ifNil:[^nil].

	"Strip the version number from the resource url"
	resourceBase _ resourceUrl copyFrom: 1 to: (resourceUrl lastIndexOf: $.) .
	"Now collect all urls that have the same resource base"
	resourceMatch _ resourceBase , '*/' , resourceFileName.
	matchingUrls _ self resourceCache keys
		select: [:entry | (resourceMatch match: entry) and: [(entry beginsWith: resourceUrl) not]].
	matchingUrls isEmpty
		ifTrue: [^nil].
	matchingUrls asSortedCollection do: [:entry | 
			candidates _ (self resourceCache at: entry).
			candidates isEmptyOrNil
				ifFalse: [candidates do: [:candidate |
					candidate = resourceFileName
						ifTrue: [^entry]]]].
	^nil