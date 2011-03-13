versions
	"Create and schedule a changelist browser on the versions of the 
	selected message."

	| class selector |
	controller controlTerminate.
	listIndex = 0 ifFalse: [
		class _ parent selectedClassOrMetaClass.
		selector _ parent selectedMessageName.
		ChangeList
			browseVersionsOf: (class compiledMethodAt: selector)
			class: parent selectedClass
			meta: class isMeta
			category: (class whichCategoryIncludesSelector: selector)
			selector: selector].
	controller controlInitialize