viewBox: newViewBox 
	| vb |
	worldState resetDamageRecorder.	"since we may have moved, old data no longer valid"
	((vb := self viewBox) isNil or: [vb ~= newViewBox]) 
		ifTrue: [worldState canvas: nil].
	worldState viewBox: newViewBox.
	self bounds: newViewBox.	"works better here than simply storing into bounds"
	worldState assuredCanvas.
	"Paragraph problem workaround; clear selections to avoid screen droppings:"
	self flag: #arNote.	"Probably unnecessary"
	worldState handsDo: [:h | h releaseKeyboardFocus].
	self fullRepaintNeeded