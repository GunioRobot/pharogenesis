newOnClass: aClass 
	"Open a new class browser on this class."

	| index each newBrowser |
	newBrowser _ Browser new.
	newBrowser systemCategoryListIndex:
		(index _ SystemOrganization numberOfCategoryOfElement: aClass name).
	newBrowser classListIndex: ((SystemOrganization listAtCategoryNumber: index)
			findFirst: [:each | each == aClass name]).
	newBrowser metaClassIndicated: false.
	BrowserView openClassBrowser: newBrowser editString: nil label: 'Class Browser:', aClass name