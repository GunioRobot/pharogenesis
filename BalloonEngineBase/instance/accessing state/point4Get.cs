point4Get
	self returnTypeC:'int *'.
	^self cCoerce: workBuffer + GWPoint4 to:'int *'