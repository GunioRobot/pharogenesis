moveBy: delta
	positionWhenComposed _ (positionWhenComposed ifNil: [ container origin ]) + delta.
	container _ container translateBy: delta
