on: aTransferMorph
	self color: Color transparent.
	transferMorph _ aTransferMorph.
	transferMorph addDependent: self.
	World currentWorld addMorph: self