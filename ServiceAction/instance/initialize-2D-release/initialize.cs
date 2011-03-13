initialize
	self
		action: [].
	self
		condition: [true].
	self text: 'no op'.
	self requestor: Requestor new.
	self id: #none.
	enabled := true