enter: aString
	"Enter the project with the given name"
	^ ((self named: aString) ifNil: [^ Project current]) enter