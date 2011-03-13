frameSize
	"Answer the size of temporary frame needed to run the receiver."

	(self header noMask: 16r20000)
		ifTrue: [^ SmallFrame]
		ifFalse: [^ LargeFrame]