rebuild

	| earMorph |
	updateCounter _ UpdateCounter.
	self removeAllMorphs.
	self addGateKeeperMorphs.
	GlobalListener ifNil: [
		earMorph _ (self class makeListeningToggleNew: false) asMorph.
		earMorph setBalloonText: 'Click to START listening for messages'.
		earMorph on: #mouseUp send: #startListening to: self.
	] ifNotNil: [
		earMorph _ (self class makeListeningToggleNew: true) asMorph.
		earMorph setBalloonText: 'Click to STOP listening for messages'.
		earMorph on: #mouseUp send: #stopListening to: self.
	].
	self addARow: {self inAColumn: {earMorph}}.
	self
		addARow: {
			self inAColumn: {(StringMorph contents: 'Incoming communications') lock}.
			self indicatorFieldNamed: #working color: Color blue help: 'working'.
			self indicatorFieldNamed: #communicating color: Color green help: 'receiving'.
		}.
	"{thumbForm. newObject. senderName. ipAddressString}"
	self class globalIncomingQueueCopy do: [ :each |
		self
			addNewObject: each second 
			thumbForm: each first 
			sentBy: each third 
			ipAddress: each fourth.
	].