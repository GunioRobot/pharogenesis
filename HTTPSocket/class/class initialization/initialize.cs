initialize
	"HTTPSocket initialize"

	ParamDelimiters _ ' ', CrLf.
	HTTPPort _ 80.
	HTTPProxyServer _ nil.
	HTTPBlabEmail _ ''.  "	'From: somebody@no.where', CrLf	"
	HTTPProxyCredentials _ ''.

	ExternalSettings registerClient: self