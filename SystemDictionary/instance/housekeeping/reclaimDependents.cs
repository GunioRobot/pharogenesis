reclaimDependents		"Smalltalk reclaimDependents"
	"Reclaim unused entries in DependentsFields (DF)..."
	"NOTE:  if <object>addDependent: is ever used to add something
		other than a view, this process will fail to reinstate that
		thing after clearing out DependentsFields.  DF was only
		intended to be used as part of the MVC architecture."
	Object classPool at: #DependentsFields  "Remove all entries from DF"
				put: IdentityDictionary new.
	Smalltalk garbageCollect.  "If that was the only reference, they will go away"
	"Now if any views of non-models remain,
		they should be reinstated as dependent views..."
	View allSubInstancesDo:
		[:v | (v model==nil or: [v model isKindOf: Model])
				ifFalse: [v model addDependent: v]].
	SystemWindow allSubInstancesDo:
		[:v | (v model==nil or: [v model isKindOf: Model])
				ifFalse: [v model addDependent: v]].
