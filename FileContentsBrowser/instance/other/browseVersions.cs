browseVersions
	"Create and schedule a message set browser on all versions of the 
	currently selected message selector."
	| class selector |
	(selector _ self selectedMessageName) ifNotNil:
		[class _ self selectedClassOrMetaClass.
		(class exists and: [class realClass includesSelector: selector]) ifTrue:
			[VersionsBrowser
				browseVersionsOf: (class realClass compiledMethodAt: selector)
				class: class realClass theNonMetaClass
				meta: class realClass isMeta
				category: self selectedMessageCategoryName
				selector: selector]]