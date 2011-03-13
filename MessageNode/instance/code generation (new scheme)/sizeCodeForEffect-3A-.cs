sizeCodeForEffect: encoder

	special > 0 
		ifTrue: [^self perform: (NewStyleMacroSizers at: special) with: encoder with: false].
	^super sizeCodeForEffect: encoder