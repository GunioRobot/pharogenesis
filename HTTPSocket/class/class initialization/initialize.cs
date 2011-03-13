initialize
	"HTTPSocket initialize"

	ParamDelimiters := ' ', CrLf.
	HTTPPort := 80.
	self httpProxyServer: nil.
	HTTPBlabEmail := ''.  "	'From: somebody@no.where', CrLf	"
	HTTPProxyCredentials := ''.

	ExternalSettings registerClient: self