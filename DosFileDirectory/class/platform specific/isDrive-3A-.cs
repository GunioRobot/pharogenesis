isDrive: fullName
	^ (fullName size = 2 and: [fullName first isLetter and: [fullName last = $:]])
		or: [(fullName beginsWith: '\\') and: [(fullName occurrencesOf: $\) <= 3]]