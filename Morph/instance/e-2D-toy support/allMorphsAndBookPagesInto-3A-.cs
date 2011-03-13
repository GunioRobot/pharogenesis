allMorphsAndBookPagesInto: aSet
	"Return a set of all submorphs.  Don't forget the hidden ones like BookMorph pages that are not showing." 

	submorphs do: [:m | m allMorphsAndBookPagesInto: aSet].
	self allNonSubmorphMorphs do: [:m | 
		(aSet includes: m) ifFalse: [		"Stop infinite recursion"
			m allMorphsAndBookPagesInto: aSet]].
	aSet add: self.
	^ aSet
	