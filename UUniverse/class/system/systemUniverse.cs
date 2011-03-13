systemUniverse
	"return the universe this image uses"
	^SystemUniverse ifNil: [ SystemUniverse _ self developmentUniverse ]