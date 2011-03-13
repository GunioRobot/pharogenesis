handleNewAudioChatFrom: dataStream sentBy: senderName ipAddress: ipAddressString

	| compressed |

	compressed _ self newCompressedSoundFrom: dataStream.
DebugLog ifNotNil: [
	DebugLog add: {compressed}.
].

	self newAudioMessages nextPut: compressed.
	self playOnArrival ifTrue: [self playNextAudioMessage].
	
