onSubProtocolOf: aClass 
	"Initialize with the entire protocol for the class, aClass,
		but excluding those inherited from Object."
	| selectors |
	selectors := Set new.
	(aClass withAllSuperclasses copyWithout: Object) do:
		[:each | selectors addAll: each selectors].
	self initListFrom: selectors asSortedCollection
		highlighting: aClass