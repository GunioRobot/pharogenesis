spawnHierarchyForClass: aClass selector: aSelector
        "Create and schedule a new class hierarchy browser on the requested class/selector."
        | newBrowser view |
        ((aClass == nil) | (aSelector == nil))  ifTrue: [^ self].
        newBrowser _ HierarchyBrowser new initHierarchyForClass: aClass
                        meta: aClass isMeta.
        view _ BrowserView systemCategoryBrowser: newBrowser editString: nil.
        Browser postOpenSuggestion: (Array with: aClass 
                        with: aSelector).
        BrowserView openBrowserView: view
                label: aClass name , ' hierarchy'

"Utilities spawnHierarchyForClass: SmallInteger selector: #hash"