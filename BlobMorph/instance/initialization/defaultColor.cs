defaultColor
	"answer the default color/fill style for the receiver"
	^ random next < 0.25
		ifTrue: [Color random]
		ifFalse: [Color random alpha: random next * 0.4 + 0.4]