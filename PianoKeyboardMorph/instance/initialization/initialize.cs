initialize
	"initialize the state of the receiver"
	super initialize.
	""
	
	whiteKeyColor _ Color gray: 0.95.
	blackKeyColor _ Color black.
	playingKeyColor _ Color red.
	nOctaves _ 6.
	self buildKeyboard.
	soundPrototype _ FMSound brass1 duration: 9.9