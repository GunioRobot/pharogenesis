setPassword: aString
	"We also clear the random extra password."

	password := SecureHashAlgorithm new hashMessage: aString.
	newPassword := nil