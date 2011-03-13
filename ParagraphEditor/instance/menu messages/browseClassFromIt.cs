browseClassFromIt
	"Launch a browser for the class indicated by the current selection. 
	If multiple classes matching the selection exist, let the user choose among them."
	| aBrow aClass |
	self
		lineSelectAndEmptyCheck: [^ self].
	aClass := Utilities
				classFromPattern: (self selection string copyWithout: Character cr)
				withCaption: 'choose a class to browse...'.
	aClass
		ifNil: [^ view flash].
	self
		terminateAndInitializeAround: 
			[aBrow := SystemBrowser default new.
			aBrow setClass: aClass selector: nil.
			aBrow class
				openBrowserView: (aBrow openEditString: nil) label: 'System Browser'].