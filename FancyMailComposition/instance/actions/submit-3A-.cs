submit: sendNow

	| message |

	messageText _ self breakLines: self completeTheMessage atWidth: 999.
	message _ MailMessage from: messageText.
	SMTPClient
			deliverMailFrom: message from 
			to: (Array with: message to) 
			text: message text 
			usingServer: self smtpServer.
	self forgetIt.
