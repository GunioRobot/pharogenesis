allCallsOn
	"Answer a SortedCollection of all the methods that refer to me by name or as part of an association in a global dict."


	^ (self  systemNavigation allCallsOn:  (self environment associationAt: self theNonMetaClass name)), (self  systemNavigation allCallsOn:  self theNonMetaClass name)	