adjustToRename: newName from: oldName
	"Adjust the resource manager to the current download location. A project might have been moved manually to a different location or server."
	| urlMap oldUrl |
	newName isEmptyOrNil ifTrue: [^self].
	urlMap _ Dictionary new.
	self resourceMap
		keysDo: [:locator | 
			oldUrl _ locator urlString.
			locator adjustToRename: newName from: oldName.
			urlMap at: oldUrl put: locator urlString].
	self resourceMap rehash.
	unloaded rehash.
	urlMap keysAndValuesDo: [:old :new |
		ResourceManager renameCachedResource: old to: new]