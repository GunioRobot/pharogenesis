setPassword: aString
	"We also clear the random extra password."

	password _ SecureHashAlgorithm new hashMessage: aString.
	newPassword _ nil