adjustToNewServer: newResourceUrl from: oldResourceUrl
	"Adjust the resource manager to the current download location. A project might have been moved manually to a different location or server."
	| urlMap oldUrl newUrl |
	newResourceUrl isEmptyOrNil ifTrue: [^self].
	urlMap _ Dictionary new.
	self resourceMap
		keysDo: [:locator | 
			"Local file refs are not handled well, so work around here"
			oldUrl _ ResourceLocator make: locator urlString relativeTo: oldResourceUrl.
			newUrl _ ResourceLocator make: locator urlString relativeTo: newResourceUrl.
			oldUrl ~= newUrl
				ifTrue: [urlMap at: oldUrl asString unescapePercents put: newUrl asString unescapePercents]].
	self resourceMap rehash.
	unloaded rehash.
	urlMap keysAndValuesDo: [:old :new |
		ResourceManager renameCachedResource: old to: new]