browseHierarchy: aClass selector: aSelector
	"Open a browser"
	| newBrowser |
	(aClass == nil)  ifTrue: [^ self].
	(newBrowser := SystemBrowser default new) setClass: aClass selector: aSelector.
	newBrowser spawnHierarchy.