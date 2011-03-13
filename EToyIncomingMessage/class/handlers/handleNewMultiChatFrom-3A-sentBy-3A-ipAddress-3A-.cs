handleNewMultiChatFrom: dataStream sentBy: senderName ipAddress: ipAddressString

	^ EToyMultiChatMorph 
		chatFrom: ipAddressString 
		name: senderName 
		text: (self newObjectFromStream: dataStream).
	