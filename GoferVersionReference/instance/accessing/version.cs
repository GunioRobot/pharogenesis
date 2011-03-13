version
	"Answer the Monticello version of the receiver."

	^ self repository loadVersionFromFileNamed: self fullName , '.mcz'