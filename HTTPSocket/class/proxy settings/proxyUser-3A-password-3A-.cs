proxyUser: userName password: password
	"Store  HTTP 1.0 basic authentication credentials
	Note: this is an ugly hack that stores your password
	in your image.  It's just enought to get you going
	if you use a firewall that requires authentication"

    | stream encodedStream |
	stream _ ReadWriteStream on: (String new: 16).
	stream nextPutAll: userName ,':' , password.
	encodedStream _ Base64MimeConverter mimeEncode: stream.
	HTTPProxyCredentials _ 'Proxy-Authorization: Basic ' , (encodedStream contents) , String crlf