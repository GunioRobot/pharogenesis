asMultipartText
	"Return a multipart mime-formatted text otherwise equivalent to this  
	message."
	| attachmentSeparator newText strm |
	self body isMultipart ifTrue: [^ self text].
	attachmentSeparator _ MailMessage generateSeparator.
	newText _ String new: 200.
	strm _ WriteStream on: newText.
	strm nextPutAll: 'Mime-Version: 1.0';
	 cr;
	 nextPutAll: 'Content-Type: multipart/mixed; boundary="';
	 nextPutAll: attachmentSeparator;
	 nextPut: $";
	 cr;
	 nextPutAll: self fieldsAsMimeHeader;
	 cr;
	 cr;
	 nextPutAll: '--' , attachmentSeparator;
	 cr;
	 nextPutAll: 'Content-Type: text/plain; charset="us-ascii"';
	 cr;
	 cr;
	 nextPutAll: self content;
	 cr;
	 nextPutAll: '--' , attachmentSeparator;
	 cr.
	^strm contents