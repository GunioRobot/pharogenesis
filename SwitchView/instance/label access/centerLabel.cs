centerLabel
	"Align the center of the label with the center of the receiver's window."
	label == nil  ifFalse: 
		[(label isKindOf: Paragraph)
			ifTrue: ["Compensate for leading in default style"
					label align: label boundingBox center + (0@1)
							with: self getWindow center]
			ifFalse: [label align: label boundingBox center 
							with: self getWindow center]]