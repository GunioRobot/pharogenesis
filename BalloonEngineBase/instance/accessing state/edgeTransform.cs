edgeTransform
	self returnTypeC:'float *'.
	^self cCoerce: workBuffer + GWEdgeTransform to:'float *'