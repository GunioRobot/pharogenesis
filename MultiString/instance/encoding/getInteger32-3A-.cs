getInteger32: location

	| integer |
	integer := 
		((self basicAt: location) bitShift: 24) +
		((self basicAt: location+1) bitShift: 16) +
		((self basicAt: location+2) bitShift: 8) +
		(self basicAt: location+3).

	integer > 1073741824 ifTrue: [^ 1073741824 - integer ].
	^ integer.
