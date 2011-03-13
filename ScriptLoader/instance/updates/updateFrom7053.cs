updateFrom7053
	"self new updateFrom7053"
	
	Smalltalk allClassesAndTraits do: [:t | 
		(t methodDict keys select: [:s | t includesLocalSelector: s]) do: [:s | 
		t notifyUsersOfChangedSelectors: {s}].
	(t classSide methodDict keys select: [:s | t classSide includesLocalSelector: s]) do: [:s |
          t classSide notifyUsersOfChangedSelectors: {s}]].	

	"[Explanation: It originates in the update from 7048 to 7049 where some classes are recompiled. This also recompiles the trait methods in those classes. This breaks the assumption in #moveChangesTo: that a method needs to be moved to the new changes file only if it is not from a trait or if it is from a trait but with a supersend (this is assumed to be the only case for which traits methods are not identical with the original method in the trait). Since this is not the case after the recompilation, now there are some old methods not moved to the new changes and hence they still have old pointers].
"
	self script83.

	self installingDefaultRepositoriesToPackages. 
	
	self flushCaches.