buildMessageForMailOutWithUser: userName

	| message compressBuffer compressStream data compressedStream compressTarget |

	"prepare the message"
	message := MailMessage empty.
	message setField: 'from' toString: userName.
	message setField: 'to' toString: 'squeak-dev@lists.squeakfoundation.org'.
	message setField: 'subject' toString: (self chooseSubjectPrefixForEmail, name). 

	message body: (MIMEDocument contentType: 'text/plain' content: (String streamContents: [ :str |
		str nextPutAll: 'from preamble:'; cr; cr.
		self fileOutPreambleOn: str ])).

	"Prepare the gzipped data"
	data _ WriteStream on: String new.
	data header; timeStamp.
	self fileOutPreambleOn: data.
	self fileOutOn: data.
	self fileOutPostscriptOn: data.
	data trailer.
	data _ ReadStream on: data contents.
	compressBuffer _ ByteArray new: 1000.
	compressStream _ GZipWriteStream on: (compressTarget _ WriteStream on: (ByteArray new: 1000)).
	[data atEnd]
		whileFalse: [compressStream nextPutAll: (data nextInto: compressBuffer)].
	compressStream close.
	compressedStream _ ReadStream on: compressTarget contents asString.

	message addAttachmentFrom: compressedStream withName: (name, '.cs.gz').

	^ message