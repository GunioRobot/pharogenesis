spawnHierarchy
        "Create and schedule a new class hierarchy browser on the currently selected class or meta."
        | newBrowser view |
        classListIndex = 0 ifTrue: [^ self].
        newBrowser _ HierarchyBrowser new initHierarchyForClass: self selectedClass 
                        meta: self metaClassIndicated.
        view _ BrowserView systemCategoryBrowser: newBrowser editString: nil.
        Browser postOpenSuggestion: (Array with: self selectedClassOrMetaClass 
                        with: self selectedMessageName).
        BrowserView openBrowserView: view
                label: self selectedClassName , ' hierarchy'