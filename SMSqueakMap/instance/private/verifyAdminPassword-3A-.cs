verifyAdminPassword: aString
	"Answer true if it is the correct password."

	^adminPassword = (SecureHashAlgorithm new hashMessage: aString)