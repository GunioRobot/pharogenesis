registerInOpenMenu
	"Register the receiver in the system's open menu"
	TheWorldMenu registerOpenCommand: {'http proxy editor'. {HTTPProxyEditor. #open}. 'An editor for the http proxy settings'}