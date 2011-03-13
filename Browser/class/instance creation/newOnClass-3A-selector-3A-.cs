newOnClass: aClass selector: aSymbol
	"Open a new class browser on this class."
	| newBrowser |

	newBrowser _ Browser new.
	newBrowser setClass: aClass selector: aSymbol.
	Browser openBrowserView: (newBrowser openOnClassWithEditString: nil)
			label: 'Class Browser: ', aClass name
