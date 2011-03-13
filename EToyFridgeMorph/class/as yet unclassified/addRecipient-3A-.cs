addRecipient: aSenderMorph

	self fridgeRecipients do: [ :each |
		aSenderMorph ipAddress = each ipAddress ifTrue: [^self]
	].
	self fridgeRecipients add: aSenderMorph.
	UpdateCounter _ self updateCounter + 1
