pageBBox
	| pageSize offset bbox |
	pageSize _ self defaultImageableArea.
	offset _ (pageSize extent x - psBounds extent x) / 2 @ 
			((pageSize extent y - psBounds extent y) /2 ).
	offset _ offset + self defaultMargin.
	bbox _ offset extent:psBounds extent.
	^bbox