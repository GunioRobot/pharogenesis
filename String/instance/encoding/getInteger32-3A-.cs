getInteger32: location
	| integer |
	<primitive: 'getInteger' module: 'IntegerPokerPlugin'>
	"^IntegerPokerPlugin doPrimitive: #getInteger"

	"the following is about 7x faster than interpreting the plugin if not compiled"

	integer := 
		((self byteAt: location) bitShift: 24) +
		((self byteAt: location+1) bitShift: 16) +
		((self byteAt: location+2) bitShift: 8) +
		(self byteAt: location+3).

	integer > 1073741824 ifTrue: [
		^1073741824 - integer ].
	^integer
