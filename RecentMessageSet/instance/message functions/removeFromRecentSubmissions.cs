removeFromRecentSubmissions
	"Remove the currently-selected method from the RecentSubmissions list"

	| aClass methodSym |
	((aClass _ self selectedClassOrMetaClass) notNil and: [(methodSym _ self selectedMessageName) notNil])
		ifTrue: 
			[Utilities purgeFromRecentSubmissions: (MethodReference new setStandardClass: aClass methodSymbol: methodSym).
			self reformulateList]