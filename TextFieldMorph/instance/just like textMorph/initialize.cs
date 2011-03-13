initialize
	"set up the field"

	| tm |
	super initialize.
	self color: Color veryLightGray lighter.
	self addMorph: (tm _ TextMorph new).
	tm fillingOnOff.  "filling on"