spawnHierarchy
	"Create and schedule a new class hierarchy browser on the currently selected class or meta."
	| newBrowser aSymbol aBehavior messageCatIndex selectedClassOrMetaClass |
	(selectedClassOrMetaClass _ self selectedClassOrMetaClass) ifNil: [^ self].
	newBrowser _ HierarchyBrowser new initHierarchyForClass: selectedClassOrMetaClass.
	(aSymbol _ self selectedMessageName) ifNotNil:
		[aBehavior _ selectedClassOrMetaClass.
		messageCatIndex _ aBehavior organization numberOfCategoryOfElement: aSymbol.
		newBrowser messageCategoryListIndex: messageCatIndex + 1.
		newBrowser messageListIndex:
			((aBehavior organization listAtCategoryNumber: messageCatIndex)
						indexOf: aSymbol)].
	Browser openBrowserView: (newBrowser openSystemCatEditString: nil)
		label: self selectedClassName , ' hierarchy'