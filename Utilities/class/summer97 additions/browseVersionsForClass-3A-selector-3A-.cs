browseVersionsForClass: aClass selector: aSelector
	VersionsBrowser
		browseVersionsOf: (aClass compiledMethodAt: aSelector)
		class: aClass
		meta: aClass isMeta
		category: (aClass organization categoryOfElement: aSelector)
		selector: aSelector