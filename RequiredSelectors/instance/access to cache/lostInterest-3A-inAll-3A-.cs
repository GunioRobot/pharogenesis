lostInterest: client inAll: classes
	ProvidedSelectors current 
		lostInterest: self 
		inAll: (classes gather: [:cl | cl withAllSuperclasses]).
	LocalSends current 
		lostInterest: self 
		inAll: (classes gather: [:cl | cl withAllSuperclasses]).
	super lostInterest: client inAll: classes
