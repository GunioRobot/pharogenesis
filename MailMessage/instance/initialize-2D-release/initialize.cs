initialize
	"initialize as an empty message"

	text _ String cr.
	fields := Dictionary new.
	body _ MIMEDocument contentType: 'text/plain' content: String cr