mouseDown: evt
	"We use shift drag to 'tear off' a thumbnail"

	evt shiftPressed ifTrue: [^ self makeThumbnailInHand: evt hand].
	^ super mouseDown: evt
		