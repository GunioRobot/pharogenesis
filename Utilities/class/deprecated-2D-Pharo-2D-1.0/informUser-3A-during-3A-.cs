informUser: aString during: aBlock
	"Display the message as progress during execution of the given block."
	"UIManager default informUser: 'Just a sec!' during: [(Delay forSeconds: 1) wait]"

	self deprecated: 'Use ''UIManager default informUser: during:'' instead.' on: '10 July 2009' in: #Pharo1.0.
	^ UIManager default informUser: aString during: aBlock