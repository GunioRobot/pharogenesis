registerInOpenMenu
	"Register the receiver in the system's open menu"

	TheWorldMenu registerOpenCommand: 
		{ 'email reader' . { Celeste . #open }. '"Celeste", an e-mail client' }
	