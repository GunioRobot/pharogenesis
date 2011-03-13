correctPassword: aPassword
	"We store the password as a SHA hash so that we can let the slave maps
	have them too. Also check the optional new random password."

	| try |
	aPassword isEmptyOrNil ifTrue:[^false].
	try := SecureHashAlgorithm new hashMessage: aPassword.
	^password = try or: [newPassword = try]