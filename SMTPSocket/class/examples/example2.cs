example2
	"SMTPSocket example2"
	"send a message using the low-level protocol methods.  Normally one would just use the high-level class message"

	| sock |
	sock _ self new.
	sock connectToSMTPServer: 'localhost'.
	sock mailFrom: 'lex@cc.gatech.edu'.
	sock recipient: 'lex@localhost'.
	sock recipient: 'root'.
	sock data:
'From: test
To: "not listed"
Subject: this is a test

Hi, this is a test message.
'.
	sock quit.
	sock close.