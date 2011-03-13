loseInterestsFor: behavior 
	RequiredSelectors current lostInterest: self in: behavior.
	LocalSends current lostInterest: self in: behavior.
	^ProvidedSelectors current lostInterest: self
		inAll: behavior withAllSuperclasses