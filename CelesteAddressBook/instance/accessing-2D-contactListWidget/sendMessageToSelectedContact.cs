sendMessageToSelectedContact
	"selectedContact must be not nil or an error will arise!"
	|message|
	message _ self buildMessageForSelectedContact.
	CelesteComposition
				openForCeleste: Celeste current 
				initialText: message text.