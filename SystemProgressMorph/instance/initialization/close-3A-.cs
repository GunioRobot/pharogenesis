close: aBlock
	| slot |
	slot _ aBlock value: SmallInteger maxVal. "This should prevent a redraw"
	self freeSlot: slot
	
