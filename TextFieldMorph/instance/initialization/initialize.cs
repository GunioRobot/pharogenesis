initialize
	"initialize the state of the receiver"
	| tm |
	super initialize.
	""
	
	self addMorph: (tm _ TextMorph new).
	tm fillingOnOff