loadFull
	"Go through the list of known master servers, ping
	each one using simple http get on a known 'ping'-url
	until one responds and then load the full map from it."
 
	self loadUpdatesFull: true