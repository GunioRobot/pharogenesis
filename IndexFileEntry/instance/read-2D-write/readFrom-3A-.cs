readFrom: aStream
	"Initialize myself from the given text stream."

	location _ MailDB readIntegerLineFrom: aStream.
	textLength _ MailDB readIntegerLineFrom: aStream.
	time _ MailDB readIntegerLineFrom: aStream.
	self from: (self readStringLineFrom: aStream).
	self to: (self readStringLineFrom: aStream).
	self cc: (self readStringLineFrom: aStream).
	self subject: (self readStringLineFrom: aStream).