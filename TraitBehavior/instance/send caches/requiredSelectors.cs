requiredSelectors
	| sss selfSentNotProvided otherRequired |
	sss := self selfSentSelectorsFromSelectors: self allSelectors.
	selfSentNotProvided _ sss copyWithoutAll: (self allSelectors select: [:e | (self >> e) isProvided]).
	otherRequired _ self allSelectors select: [:e | (self >> e) isRequired].
	^(selfSentNotProvided, otherRequired) asSet
