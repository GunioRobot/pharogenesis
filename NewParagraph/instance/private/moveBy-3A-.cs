moveBy: delta
	lines do: [:line | line moveBy: delta].
	positionWhenComposed _ positionWhenComposed + delta.
	container _ container translateBy: delta