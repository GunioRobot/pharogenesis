affordsUniclass
	"Answer true iff the receiver operates on behalf of an object that is, or could become, a member of a Uniclass"

	| viewee |
	^ (viewee _ self objectViewed) belongsToUniClass or: 
			[((viewee isKindOf: Integer) not and: 
				[(viewee isKindOf: Behavior) not]) and:
					[self userLevel > 0]]