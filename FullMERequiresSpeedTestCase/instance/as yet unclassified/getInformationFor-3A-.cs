getInformationFor: classes 
	classes do: 
			[:interestingCl | 
			interestingCl withAllSuperclassesDo: 
					[:cl | 
					LocalSends current for: cl.
					ProvidedSelectors current for: cl.
					RequiredSelectors current for: cl]]