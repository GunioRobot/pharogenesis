doDup: evt fromHalo: halo handle: dupHandle

	selectedItems _ self duplicateMorphCollection: selectedItems.
	selectedItems do: [:m | self owner addMorph: m].
	dupDelta isNil
		ifTrue: ["First duplicate operation -- note starting location"
				dupLoc _ self position.
				evt hand grabMorph: self.
				halo removeAllHandlesBut: dupHandle]
		ifFalse: ["Subsequent duplicate does not grab, but only moves me and my morphs"
				dupLoc _ nil.
				self position: self position + dupDelta]