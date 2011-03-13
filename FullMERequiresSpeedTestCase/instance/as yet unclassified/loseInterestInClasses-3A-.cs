loseInterestInClasses: classes 
	classes do: [:interestingCl | 
		RequiredSelectors current lostInterest: self in: interestingCl.
		interestingCl withAllSuperclassesDo: [:cl | 
			ProvidedSelectors current lostInterest: self in: cl.
			LocalSends current lostInterest: self in: cl]]