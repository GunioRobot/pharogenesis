allStringsAfter: aSubmorph
	"return an OrderedCollection of strings of text in my submorphs.  If aSubmorph is non-nil, begin with that container."

	| list string ok |
	list _ OrderedCollection new.
	ok _ aSubmorph == nil.
	self allMorphsDo: [:sub | 
		ok ifFalse: [ok _ sub == aSubmorph].		"and do this one too"
		ok ifTrue: [
			(string _ sub userString) ifNotNil: [
				(string isKindOf: String) 
					ifTrue: [list add: string]
					ifFalse: [list addAll: string]]]].
	^ list