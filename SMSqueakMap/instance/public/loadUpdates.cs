loadUpdates
	"Go through the list of known master servers, ping
	each one using simple http get on a known 'ping'-url
	until one responds and then load updates from it."

	"SM2 starts with using full always"

	self loadFull