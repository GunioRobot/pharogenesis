chooseFrame
	"Answer a new frame, depending on whether the view is currently 
	collapsed or not."
	| labelForm f |
	self isCollapsed & expandedViewport notNil
		ifTrue:
			[labelForm _ bitsValid
				ifTrue: [windowBits]
				ifFalse: [Form fromDisplay: self labelDisplayBox].
			bitsValid _ false.
			self erase.
			labelForm slideFrom: self labelDisplayBox origin
					to: expandedViewport origin-self labelOffset
					nSteps: 10.
			^ expandedViewport]
		ifFalse:
			[f _ self getFrame.
			bitsValid _ false.
			self erase.
			^ f topLeft + self labelOffset extent: f extent]