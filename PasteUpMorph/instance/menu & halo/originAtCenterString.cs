originAtCenterString
	^ (self hasProperty: #originAtCenter)
		ifTrue:
			['stop origin-at-center']
		ifFalse:
			['start origin-at-center']
