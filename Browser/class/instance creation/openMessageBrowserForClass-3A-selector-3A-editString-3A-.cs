openMessageBrowserForClass: aBehavior selector: aSymbol editString: aString
	"Create and schedule a message browser for the class, aBehavior, in 
	which the argument, aString, contains characters to be edited in the text 
	view. These characters are the source code for the message selector 
	aSymbol."

	| newBrowser |
	(newBrowser := self new) setClass: aBehavior selector: aSymbol.
	^ self openBrowserView: (newBrowser openMessageEditString: aString)
		label: newBrowser selectedClassOrMetaClassName , ' ' , newBrowser selectedMessageName
