handleNewChatFrom: dataStream sentBy: senderName ipAddress: ipAddressString

	^ EToyChatMorph 
		chatFrom: ipAddressString 
		name: senderName 
		text: (self newObjectFromStream: dataStream).
	