composedWith: aTransform
	"Return a new transform that has the effect of transforming points first by the receiver and then by the argument."

	self isPureTranslation ifTrue:
		[^ aTransform copy setOffset: offset + aTransform offset].
	aTransform isPureTranslation ifTrue:
		[^ self copy setOffset: offset + aTransform offset].
self halt: 'general composition not yet implemented'
