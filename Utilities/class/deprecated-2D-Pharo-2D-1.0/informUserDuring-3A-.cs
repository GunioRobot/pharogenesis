informUserDuring: aBlock
	"Display a message as progress during execution of the given block."
	
	self deprecated: 'Use ''UIManager default informUserDuring:'' instead' on: '10 July 2009' in: #Pharo1.0.
	^ UIManager default informUserDuring: aBlock