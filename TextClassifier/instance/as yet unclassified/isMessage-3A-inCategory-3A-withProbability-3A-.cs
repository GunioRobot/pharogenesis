isMessage: msg inCategory: categoryName withProbability: threshold
	^ (self probabilityOf: msg beingIn: categoryName) >= threshold