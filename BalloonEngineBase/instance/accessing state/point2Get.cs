point2Get
	self returnTypeC:'int *'.
	^self cCoerce: workBuffer + GWPoint2 to:'int *'