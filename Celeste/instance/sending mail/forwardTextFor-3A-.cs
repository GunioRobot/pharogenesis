forwardTextFor: msgID
	"Answer the template for forwarding the message with the given ID."
	| msg separator |
	msg := self currentMessage.

	^String streamContents: [ :str |
		"From header"
		str nextPutAll: 'From: ';
		nextPutAll: self account userName; cr.

		"Put a blank To"
		str nextPutAll: 'To: '; cr.

		"Add a subject modified from the original"
		str nextPutAll: 'Subject: (fwd) '.
		str nextPutAll: msg subject.
		str cr.


		"Add auto-cc if it's been set"
		self account ccList isEmpty ifFalse: [
			str nextPutAll: 'Cc: '.
			str nextPutAll: self account ccList; cr].

		"add the mime headers to make it multi-part"
		separator := MailMessage generateSeparator.
		str nextPutAll: 'MIME-Version: 1.0'; cr.
		str nextPutAll: 'Content-type: multipart/mixed; boundary="'.
		str nextPutAll: separator; nextPut: $".
		str cr.

		"skip down to the main part of the message"
		str cr.
		str nextPutAll: '--'; nextPutAll: separator; cr.
		str nextPutAll: 'Content-type: text/plain'; cr; cr.

		"insert the forwarded message"
		str cr; cr; nextPutAll: '====forwarded===='; cr; cr.
		str nextPutAll: '--'; nextPutAll: separator; cr.
		str nextPutAll: 'Content-type: message/rfc822'; cr; cr.
		str nextPutAll: msg text; cr.

		"final separator"
		str nextPutAll: '--'; nextPutAll: separator; nextPutAll: '--'; cr.
	].