putInteger32: anInteger at: location

	| integer |
	integer _ anInteger.
	integer < 0 ifTrue: [integer :=  1073741824 - integer. ].
	self basicAt: location+3 put: (integer \\ 256).
	self basicAt: location+2 put: (integer bitShift: -8) \\ 256.
	self basicAt: location+1 put: (integer bitShift: -16) \\ 256.
	self basicAt: location put: (integer bitShift: -24) \\ 256.
