example
	"Base64MimeConverter example"

| ss bb | 
ss _ ReadWriteStream on: (String new: 10).
ss nextPutAll: 'Hi There!'.
bb _ Base64MimeConverter mimeEncode: ss.
	"bb contents  'SGkgVGhlcmUh'"
^ (Base64MimeConverter mimeDecodeToChars: bb) contents

