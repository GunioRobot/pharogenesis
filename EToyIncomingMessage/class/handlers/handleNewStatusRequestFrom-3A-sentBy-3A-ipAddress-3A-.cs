handleNewStatusRequestFrom: dataStream sentBy: senderName ipAddress: ipAddressString

	"more later"

	^ EToyChatMorph 
		chatFrom: ipAddressString 
		name: senderName 
		text: ipAddressString,' would like to know if you are available'.
	