point1Get
	self returnTypeC:'int *'.
	^self cCoerce: workBuffer + GWPoint1 to:'int *'