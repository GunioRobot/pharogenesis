getMessage
	"Answer the MailMessage for this index file entry."
	^ MailMessage from: (self rawText)