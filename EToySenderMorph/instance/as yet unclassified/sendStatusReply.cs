sendStatusReply

	| null |
	null _ String with: 0 asCharacter.
	EToyPeerToPeer new 
		sendSomeData: {
			EToyIncomingMessage typeStatusReply,null. 
			Preferences defaultAuthorName,null.
			((EToyGateKeeperMorph acceptableTypesFor: self ipAddress) 
				eToyStreamedRepresentationNotifying: self).
		}
		to: self ipAddress
		for: self.
