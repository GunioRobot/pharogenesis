potentialClassNames
	"Answer the names of all the classes that could be viewed in this browser.  This hook is provided so that HierarchyBrowsers can indicate their restricted subset.  For generic Browsers, the entire list of classes known to Smalltalk is provided, though of course that really only is accurate in the case of full system browsers."

	^ Smalltalk classNames