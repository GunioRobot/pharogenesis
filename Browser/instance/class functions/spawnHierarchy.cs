spawnHierarchy
	"Create and schedule a new class hierarchy browser on the currently selected class or meta."
	| newBrowser aSymbol aBehavior messageCatIndex |
	classListIndex = 0 ifTrue: [^ self].
	newBrowser _ HierarchyBrowser new initHierarchyForClass: self selectedClass 
			meta: self metaClassIndicated.
	(aSymbol _ self selectedMessageName) ifNotNil: [
		aBehavior _ self selectedClassOrMetaClass.
		messageCatIndex _ aBehavior organization numberOfCategoryOfElement: aSymbol.
		newBrowser messageCategoryListIndex: messageCatIndex.
		newBrowser messageListIndex:
			((aBehavior organization listAtCategoryNumber: messageCatIndex)
						indexOf: aSymbol)].
	Browser openBrowserView: (newBrowser openSystemCatEditString: nil)
		label: self selectedClassName , ' hierarchy'