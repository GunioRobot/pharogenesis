colorTransform
	self returnTypeC:'float *'.
	^self cCoerce: workBuffer + GWColorTransform to:'float *'