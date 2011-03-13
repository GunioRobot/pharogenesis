spawnHierarchy
	"Create and schedule a new hierarchy browser on the currently selected
	class or meta."
	| newBrowser aSymbol aBehavior messageCatIndex selectedClassOrMetaClass |
	(selectedClassOrMetaClass := self selectedClassOrMetaClass)
		ifNil: [^ self].
	selectedClassOrMetaClass isTrait
		ifTrue: [^ self].
	newBrowser := HierarchyBrowser new initHierarchyForClass: selectedClassOrMetaClass.
	((aSymbol := self selectedMessageName) notNil
			and: [(MessageSet isPseudoSelector: aSymbol) not])
		ifTrue: [aBehavior := selectedClassOrMetaClass.
			messageCatIndex := aBehavior organization numberOfCategoryOfElement: aSymbol.
			newBrowser messageCategoryListIndex: messageCatIndex + 1.
			newBrowser
				messageListIndex: ((aBehavior organization listAtCategoryNumber: messageCatIndex)
						indexOf: aSymbol)].
	Browser
		openBrowserView: (newBrowser openSystemCatEditString: nil)
		label: newBrowser labelString.
	newBrowser assureSelectionsShow