browseVersionsOf: aClass selector: aSelector
	"Open a browser"
	VersionsBrowser
		browseVersionsOf: (aClass compiledMethodAt: aSelector)
		class: aClass theNonMetaClass
		meta: aClass isMeta
		category: (aClass organization categoryOfElement: aSelector)
		selector: aSelector