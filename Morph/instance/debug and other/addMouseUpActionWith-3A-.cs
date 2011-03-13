addMouseUpActionWith: codeToRun

	((codeToRun isKindOf: MessageSend) not and: [codeToRun isEmptyOrNil]) ifTrue: [^self].
	self setProperty: #mouseUpCodeToRun toValue: codeToRun.
	self
		on: #mouseUp 
		send: #programmedMouseUp:for:
		to: self.
	self
		on: #mouseDown
		send: #programmedMouseDown:for:
		to: self.
	self
		on: #mouseEnter
		send: #programmedMouseEnter:for:
		to: self.
	self
		on: #mouseLeave
		send: #programmedMouseLeave:for:
		to: self.

