resourceCache
	^CachedResources ifNil:[
		CachedResources _ Dictionary new.
		self reloadCachedResources.
		CachedResources].