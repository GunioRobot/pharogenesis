modalWindow: aMorph 
	(self valueOfProperty: #modalWindow)
		ifNotNilDo: [:morph | morph doCancel].
	self setProperty: #modalWindow toValue: aMorph.
	aMorph
		ifNotNil: [self
				when: #aboutToLeaveWorld
				send: #removeModalWindow
				to: self]