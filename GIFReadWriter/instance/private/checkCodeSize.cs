checkCodeSize
	(freeCode > maxCode and: [codeSize < 12])
		ifTrue:
			[codeSize _ codeSize + 1.
			maxCode _ (1 bitShift: codeSize) - 1]