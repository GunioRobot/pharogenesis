adminPassword: aString
	"We store the password as a SHA hash so that we can let the slave maps
	have it too."

	adminPassword _ SecureHashAlgorithm new hashMessage: aString