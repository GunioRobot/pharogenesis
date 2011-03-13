assuredParameterDictionary
	"Private!  Answer the parameters dictionary, creating it if necessary"

	^ parameters ifNil: [parameters _ IdentityDictionary new]