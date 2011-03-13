newOnClass: aClass label: aLabel
	"Open a new class browser on this class."
	| newBrowser |

	newBrowser _ Browser new.
	newBrowser setClass: aClass selector: nil.
	Browser openBrowserView: (newBrowser openOnClassWithEditString: nil)
			label: aLabel
