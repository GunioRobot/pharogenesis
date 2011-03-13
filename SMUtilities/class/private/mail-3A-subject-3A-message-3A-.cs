mail: anAccount subject: sub message: msg
	"Send a mail to the holder of <anAccount>."

	SMTPClient
		deliverMailFrom: 'squeakmap@squeak.org'
		to: {anAccount email}
		text:
('From: SqueakMap <squeakmap@squeak.org>
To: ', anAccount email, '
Subject: ', sub,
'
', msg, (self randomPhrase), ', SqueakMap') squeakToIso usingServer: MailServer