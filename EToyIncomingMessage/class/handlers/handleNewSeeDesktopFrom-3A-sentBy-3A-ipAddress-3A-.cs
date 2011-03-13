handleNewSeeDesktopFrom: dataStream sentBy: senderName ipAddress: ipAddressString

	"more later"

	^ EToyChatMorph 
		chatFrom: ipAddressString 
		name: senderName 
		text: ipAddressString,' would like to see your desktop'.
	