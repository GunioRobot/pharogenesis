duration: aNumber
	"Set the duration of the receiver (in seconds)."
	((pitchPoints isNil or: [duration isNil]) or: [duration = 0])
		ifFalse: [pitchPoints _ pitchPoints collect: [ :each | each x / duration * aNumber @ each y]].
	duration _ aNumber