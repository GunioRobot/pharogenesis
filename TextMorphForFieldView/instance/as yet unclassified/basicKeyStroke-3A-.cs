basicKeyStroke: evt
	"Do the key if max length has not been reached.
	Don't allow tabs."

	(self localHandleKeystroke: evt) ifTrue: [^self].
	(self maxLength isNil or: [self text size < self maxLength or: [
			self editor selectionInterval size > 0 or: [self isEditEvent: evt]]])
		ifTrue: [evt keyCharacter = Character cr ifTrue: [self dialogWindow ifNotNilDo: [:w | ^w keyStroke: evt]].
				evt keyCharacter = Character escape ifTrue: [self dialogWindow ifNotNilDo: [:w | ^w keyStroke: evt]].
				super basicKeyStroke: evt]