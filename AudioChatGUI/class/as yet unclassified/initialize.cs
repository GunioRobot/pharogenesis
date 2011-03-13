initialize

	EToyIncomingMessage
		forType: EToyIncomingMessage typeAudioChat 
		send: #handleNewAudioChatFrom:sentBy:ipAddress: 
		to: self.

	EToyIncomingMessage
		forType: EToyIncomingMessage typeAudioChatContinuous
		send: #handleNewAudioChat2From:sentBy:ipAddress: 
		to: self.


