generateLocalKeyPair
	"SecurityManager default generateLocalKeyPair"
	"Generate a key set on the local machine."
	| dsa |
	dsa _ DigitalSignatureAlgorithm new.
	dsa initRandomFromString: 
		Time millisecondClockValue printString, 
		Date today printString, 
		SmalltalkImage current platformName printString.
	privateKeyPair _ dsa generateKeySet.
	self storeSecurityKeys.