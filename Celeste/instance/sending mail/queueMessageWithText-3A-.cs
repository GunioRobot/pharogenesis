queueMessageWithText: aStringOrText 
	"Queue a message to be sent later. The message is added to the database  
	and filed in the '.tosend.' category."

	| messageText id msg |

	messageText _ 'X-Mailer: ' , Celeste versionString , String cr , 'Date: ' , MailMessage dateStampNow , ' ' , self timeZoneString , ' ' , String cr.
	messageText _ messageText , aStringOrText asString.

	msg _ MailMessage from: messageText.

	"Check now that the addresses are well formed email addresses.  This prevents
	runtime errors when actually transmitting the mail"
	[MailAddressParser addressesIn: msg from] ifError:
		[ :err :rcvr | self inform: 'From: in message header', String cr, err. ^nil].
	[MailAddressParser addressesIn: msg to] ifError:
		[ :err :rcvr | self inform: 'To: in message header', String cr, err. ^nil].
	[MailAddressParser addressesIn: msg cc] ifError:
		[:err :rcvr | self inform: 'CC: in message header', String cr, err. ^nil].

	"queue the message"
	self requiredCategory: '.tosend.'.
	id _ mailDB addNewMessage: msg.
	mailDB file: id inCategory: '.tosend.'.
	self category = '.tosend.'
		ifTrue: [self updateTOC].
	self changed: #outBoxStatus.
	^ id