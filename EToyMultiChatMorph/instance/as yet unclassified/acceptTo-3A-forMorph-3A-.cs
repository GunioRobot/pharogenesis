acceptTo: someText forMorph: aMorph

	| streamedMessage betterText |

	betterText _ self improveText: someText forMorph: aMorph.
	streamedMessage _ {targetIPAddresses. betterText} eToyStreamedRepresentationNotifying: self.
	targetIPAddresses do: [ :each |
		self 
			transmitStreamedObject: streamedMessage
			to: each.
	].
	aMorph setText: '' asText.
	self appendMessage: 
		self startOfMessageFromMe,
		' - ',
		betterText,
		String cr.

	^true