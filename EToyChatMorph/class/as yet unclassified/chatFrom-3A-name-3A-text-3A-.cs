chatFrom: ipAddress name: senderName text: text

	| chatWindow |

	chatWindow := self 
		chatWindowForIP: ipAddress 
		name: senderName 
		picture: (EToySenderMorph pictureForIPAddress: ipAddress) 
		inWorld: self currentWorld.
	chatWindow
		chatFrom: ipAddress 
		name: senderName 
		text: text
