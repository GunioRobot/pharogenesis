fullOnClass: aClass 
	"Open a new full browser set to class."
	| brow |
	brow _ Browser new.
	brow setClass: aClass selector: nil.
	Browser openBrowserView: (brow openEditString: nil)
		label: 'System Browser'