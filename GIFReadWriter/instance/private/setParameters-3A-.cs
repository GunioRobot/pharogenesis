setParameters: initCodeSize
	clearCode _ 1 bitShift: initCodeSize.
	eoiCode _ clearCode + 1.
	freeCode _ clearCode + 2.
	codeSize _ initCodeSize + 1.
	maxCode _ (1 bitShift: codeSize) - 1