sendStatusCheck

	| null |
	null _ String with: 0 asCharacter.
	EToyPeerToPeer new 
		sendSomeData: {
			EToyIncomingMessage typeStatusRequest,null. 
			Preferences defaultAuthorName,null.
		}
		to: self ipAddress
		for: self.
