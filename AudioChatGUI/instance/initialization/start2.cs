start2

	Socket initializeNetwork.
	myrecorder initialize.

	self addARow: {
		self inAColumn: {
			(
				self inARow: {
					self inAColumn: {self toggleForSendWhileTalking}.
					self inAColumn: {self toggleForHandsFreeTalking}.
					self inAColumn: {self toggleForPlayOnArrival}.
				}
			) hResizing: #shrinkWrap.
			self inARow: {
				self talkBacklogIndicator.
				self messageWaitingAlertIndicator.
			}.
		}.
		self inAColumn: {
			theConnectButton _ self connectButton.
			self playButton.
			theTalkButton _ self talkButton.
		}.
	}.
