browseVersions
	"Create and schedule a message set browser on all versions of the 
	currently selected message selector."
	| class selector |
	(selector _ self selectedMessageName) ifNotNil:
		[class _ self selectedClassOrMetaClass.
		VersionsBrowser
			browseVersionsOf: (class compiledMethodAt: selector)
			class: self selectedClass
			meta: class isMeta
			category: self selectedMessageCategoryName
			selector: selector]