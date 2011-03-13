buildMessageForMailOutWithUser: userName 
	"prepare the message"
	| message compressBuffer compressStream data compressedStream compressTarget |
	message := MailMessage empty.
	message 
		setField: 'from'
		toString: userName.
	message 
		setField: 'to'
		toString: 'Pharo-project@lists.gforge.inria.fr'.
	message 
		setField: 'subject'
		toString: self chooseSubjectPrefixForEmail , name.
	message body: (MIMEDocument 
			contentType: 'text/plain'
			content: (String streamContents: 
				[ :str | 
				str
					nextPutAll: 'from preamble:';
					cr;
					cr.
				self fileOutPreambleOn: str ])).

	"Prepare the gzipped data"
	data := String new writeStream.
	data
		header;
		timeStamp.
	self fileOutPreambleOn: data.
	self fileOutOn: data.
	self fileOutPostscriptOn: data.
	data trailer.
	data := data contents readStream.
	compressBuffer := ByteArray new: 1000.
	compressStream := GZipWriteStream on: (compressTarget := (ByteArray new: 1000) writeStream).
	[ data atEnd ] whileFalse: [ compressStream nextPutAll: (data nextInto: compressBuffer) ].
	compressStream close.
	compressedStream := compressTarget contents asString readStream.
	message 
		addAttachmentFrom: compressedStream
		withName: name , '.cs.gz'.
	^ message