caseInsensitiveLessOrEqual: aString 

	^ (self multiStringCompare: self with: aString asMultiString collated: CaseInsensitiveOrder) <= 2.
