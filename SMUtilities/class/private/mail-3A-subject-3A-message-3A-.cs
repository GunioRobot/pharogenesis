mail: anAccount subject: sub message: msg
	"Send a mail to the holder of <anAccount>."

	SMTPClient
		deliverMailFrom: 'squeakmap@squeakfoundation.org'
		to: {anAccount email}
		text:
('From: SqueakMap <squeakmap@squeakfoundation.org>
To: ', anAccount email, '
Subject: ', sub,
'
', msg, (self randomPhrase), ', SqueakMap') usingServer: MailServer