quitClient
	"break the connection"

	client ifNotNil: [client quit].
	client := nil