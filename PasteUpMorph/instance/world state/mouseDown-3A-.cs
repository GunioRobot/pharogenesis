mouseDown: evt
	"Handle a mouse down event."

	self isWorldMorph
		ifTrue: [evt hand newKeyboardFocus: self.
				evt hand invokeMetaMenu: evt]
		ifFalse: [^ super mouseDown: evt]

