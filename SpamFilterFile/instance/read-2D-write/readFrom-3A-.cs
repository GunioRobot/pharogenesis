readFrom: aStream 
	self class environment at: #SpamFilter ifPresent: [:spamFilterClass |
		aStream binary; position: 0.
		filter _ spamFilterClass new.
		filter readFrom: aStream.
	].