return: value
	"Find thisContext sender that is owner of self and return from it"

	| home |
	home _ thisContext findContextSuchThat: [:ctxt | ctxt myEnv == self].
	home return: value