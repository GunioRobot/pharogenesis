browseVersions
	"Create and schedule a message set browser on all versions of the 
	currently selected message selector."
	| class selector |
	class _ self selectedClassOrMetaClass.
	selector _ self selectedMessageName.
	VersionsBrowser
		browseVersionsOf: (class compiledMethodAt: selector)
		class: self selectedClass
		meta: self selectedClass isMeta
		category: self selectedMessageCategoryName
		selector: selector