getFullInfoFor: aProject ifValid: aBlock

	^self 
		getFullInfoFor: aProject 
		ifValid: aBlock 
		expandedFormat: false