noteInterestsFor: behavior 
	RequiredSelectors current noteInterestOf: self in: behavior.
	LocalSends current noteInterestOf: self in: behavior.
	ProvidedSelectors current noteInterestOf: self
		inAll: behavior withAllSuperclasses