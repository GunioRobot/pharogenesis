validateProjectNameIfOK: aBlock

	(self hasBadNameForStoring or: [self name beginsWith: 'Unnamed']) ifFalse: [^aBlock value].
	EToyProjectDetailsMorph
		getFullInfoFor: self 
		ifValid: [
			World displayWorldSafely.
			aBlock value.
		] fixTemps.
