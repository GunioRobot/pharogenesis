bumpVersion: versString
	"Version is literal piece of file name.  Mime encoded and http encoded.  Decode and add one."

	versString isInteger ifTrue: [
		^ (Base64MimeConverter encodeInteger: versString + 1) 
					encodeForHTTP].
	^ (Base64MimeConverter encodeInteger: 
		((Base64MimeConverter decodeInteger: 
				versString unescapePercents) + 1)) 
					encodeForHTTP