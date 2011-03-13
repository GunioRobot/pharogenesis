pickColor
	"Pick a colour from the screen."

	|p d c h|
	h := self world activeHand.
	d := Delay forMilliseconds: 20.
	h showTemporaryCursor: (ScriptingSystem formAtKey: #Eyedropper) 
			hotSpotOffset: 6 negated @ 4 negated.
	[Sensor anyButtonPressed] whileFalse: 
		[[Sensor nextEvent isNil] whileFalse. "Pharo compatability"
		p := Sensor cursorPoint.
			(self hsvaMorph containsPoint: p)
				ifFalse: ["deal with the fact that 32 bit displays may have garbage in the alpha bits"
						c := Display depth = 32 
							ifTrue: [Color
									colorFromPixelValue: ((Display pixelValueAt: p) bitOr: 16rFF000000)
									depth: 32]
							ifFalse: [Display colorAt: p]].
			self world activeHand position: p.
			self selectedColor ~= c ifTrue: [
				self selectedColor: c].
			self world displayWorldSafely.
			d wait].
	h showTemporaryCursor: nil