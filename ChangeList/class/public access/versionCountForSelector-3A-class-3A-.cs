versionCountForSelector: aSelector class: aClass
	"Answer the number of versions known to the system for the given class and method, including the current version.  A result of greater than one means that there is at least one superseded version.  6/28/96 sw"
	
	| method |
	method _ aClass compiledMethodAt: aSelector.
	^ (self new
			scanVersionsOf: method class: aClass meta: aClass isMeta
			category: nil selector: aSelector) list size