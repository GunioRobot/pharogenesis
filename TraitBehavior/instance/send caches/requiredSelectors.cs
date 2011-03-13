requiredSelectors
	| sss selfSentNotProvided otherRequired |
	sss := self selfSentSelectorsFromSelectors: self allSelectors.
	selfSentNotProvided := sss copyWithoutAll: (self allSelectors select: [:e | (self >> e) isProvided]).
	otherRequired := self allSelectors select: [:e | (self >> e) isRequired].
	^(selfSentNotProvided, otherRequired) asSet
