point3Get
	self returnTypeC:'int *'.
	^self cCoerce: workBuffer + GWPoint3 to:'int *'