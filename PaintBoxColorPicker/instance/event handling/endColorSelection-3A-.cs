endColorSelection: evt
	"Update current color and report it to paint box."

	self selectColor: evt.
	(owner isKindOf: PaintBoxMorph)
		ifTrue: [owner takeColorEvt: evt from: self].

	"restore mouseLeave handling"
	self on: #mouseLeave send: #delete to: self.
	evt hand addMouseOverMorph: self.
