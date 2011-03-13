noteInterestInClasses: classes 
	classes do: 
			[:interestingCl | 
			interestingCl withAllSuperclassesDo: 
					[:cl | 
					LocalSends current noteInterestOf: self in: cl.
					ProvidedSelectors current noteInterestOf: self in: cl].
				RequiredSelectors current noteInterestOf: self in: interestingCl]