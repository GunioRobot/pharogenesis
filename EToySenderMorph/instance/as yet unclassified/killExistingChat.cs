killExistingChat

	| oldOne |
	self rubberBandCells: true. "disable growing"
	(oldOne _ self valueOfProperty: #embeddedChatHolder) ifNotNil: [
		oldOne delete.
		self removeProperty: #embeddedChatHolder
	].

	(oldOne _ self valueOfProperty: #embeddedAudioChatHolder) ifNotNil: [
		oldOne delete.
		self removeProperty: #embeddedAudioChatHolder
	].

