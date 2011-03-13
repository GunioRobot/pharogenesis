browseVersions
	"Create and schedule a message set browser on all versions of the 
	currently selected message selector."
	| class selector |
	messageListIndex ~= 0 ifTrue:
		[class _ self selectedClassOrMetaClass.
		selector _ self selectedMessageName.
		ChangeList
			browseVersionsOf: (class compiledMethodAt: selector)
			class: self selectedClass
			meta: self metaClassIndicated
			category: self selectedMessageCategoryName
			selector: selector]