example
	"SMTPSocket example"
	"send a message over SMTP"

	self deliverMailFrom: 'lex@cc.gatech.edu' to: #(root src) text:
'From: test
To: "not listed"
Subject: this is a test

Hello from Squeak!
'	usingServer: 'localhost'.
