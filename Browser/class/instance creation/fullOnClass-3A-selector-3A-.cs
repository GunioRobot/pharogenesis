fullOnClass: aClass selector: aSelector
	"Open a new full browser set to class."

	| brow |
	brow _ Browser new.
	brow setClass: aClass selector: aSelector.
	Browser openBrowserView: (brow openEditString: nil)
		label: 'System Browser'