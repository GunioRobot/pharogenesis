fullOnClass: aClass selector: aSelector
	"Open a new full browser set to class."

	| brow classToUse |
	classToUse _ Preferences browseToolClass.
	brow _ classToUse new.
	brow setClass: aClass selector: aSelector.
	classToUse openBrowserView: (brow openEditString: nil)
		label: brow defaultBrowserTitle