keyboardFocusChange: aBoolean 
	| w |
	paragraph isNil ifFalse:[paragraph focused: aBoolean].
	aBoolean 
		ifTrue: 
			["A hand is wanting to send us characters..."

			self hasFocus ifFalse: [self editor	"Forces install"]]
		ifFalse: 
			["A hand has clicked elsewhere..."

			(w := self world) isNil 
				ifFalse: 
					[w handsDo: [:h | h keyboardFocus == self ifTrue: [^self]].
					"Release control unless some hand is still holding on"
					self releaseEditor]]