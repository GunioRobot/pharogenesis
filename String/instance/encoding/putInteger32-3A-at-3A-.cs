putInteger32: anInteger at: location
	| integer |
	<primitive: 'putInteger' module: 'IntegerPokerPlugin'>
	"IntegerPokerPlugin doPrimitive: #putInteger"

	"the following is close to 20x faster than the above if the primitive is not compiled"
	"PUTCOUNTER _ PUTCOUNTER + 1."
	integer _ anInteger.
	integer < 0 ifTrue: [integer :=  1073741824 - integer. ].
	self at: location+3 put: (Character value: (integer \\ 256)).
	self at: location+2 put: (Character value: (integer bitShift: -8) \\ 256).
	self at: location+1 put: (Character value: (integer bitShift: -16) \\ 256).
	self at: location put: (Character value: (integer bitShift: -24) \\ 256).

"Smalltalk at: #PUTCOUNTER put: 0"