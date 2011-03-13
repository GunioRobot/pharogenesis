initialize
	"HTTPSocket initialize"

	ParamDelimiters := ' ', String crlf.
	HTTPPort := 80.
	self httpProxyServer: nil.
	HTTPBlabEmail := ''.  "	'From: somebody@no.where', CrLf	"
	HTTPProxyCredentials := ''.

	ExternalSettings registerClient: self