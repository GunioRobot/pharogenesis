readFrom: aStream
	"Initialize myself from the given text stream."

	location _ MailDB readIntegerLineFrom: aStream.
	textLength _ MailDB readIntegerLineFrom: aStream.
	time _ MailDB readIntegerLineFrom: aStream.
	from _ MailDB readStringLineFrom: aStream.
	to _ MailDB readStringLineFrom: aStream.
	cc _ MailDB readStringLineFrom: aStream.
	subject _ MailDB readStringLineFrom: aStream.