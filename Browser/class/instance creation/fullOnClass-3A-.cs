fullOnClass: aClass 
	"Open a new full browser set to class."
	| brow |
	brow _ self new.
	brow setClass: aClass selector: nil.
	^ self 
		openBrowserView: (brow openEditString: nil)
		label: 'System Browser'