asTextEncodingNewPart: aStream named: aName 
	"Return a multipart mime-formatted text otherwise equivalent to this      
	message, with the contents of aStream attached (base64 encoded)."
	| strm |
	strm _ WriteStream on: (String new: 100).
	strm nextPutAll: self asMultipartText;
	" cr; this bungled changeset mailouts. don't restore unless you know what you're doing."
	 nextPutAll: 'Content-Type: application/octet-stream; name="' , aName , '"';
	 cr;
	 nextPutAll: 'Content-Disposition: attachment; filename="' , aName , '"';
	 cr;
	 nextPutAll: 'Content-Transfer-Encoding: base64';
	 cr;
	 cr.
	Base64MimeConverter new dataStream: aStream;
	 mimeStream: strm;
	 mimeEncode.
	strm cr; nextPutAll: '--' , self attachmentSeparator; cr.
	^ strm contents