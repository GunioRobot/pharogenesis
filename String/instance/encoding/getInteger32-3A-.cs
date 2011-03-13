getInteger32: location
	| integer |
	<primitive: 'getInteger' module: 'IntegerPokerPlugin'>
	"^IntegerPokerPlugin doPrimitive: #getInteger"

	"the following is about 7x faster than interpreting the plugin if not compiled"

	integer := 
		((self at: location) asInteger bitShift: 24) +
		((self at: location+1) asInteger bitShift: 16) +
		((self at: location+2) asInteger bitShift: 8) +
		(self at: location+3) asInteger.

	integer > 1073741824 ifTrue: [^1073741824 - integer ].
	^integer
