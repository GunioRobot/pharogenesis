copyRecordingIn: dict
	"Copy the vertices array.  Give each one its own handles, and in the handles array."

	| new hadHandles |
	hadHandles _ handles ifNil: [false] ifNotNil: [self removeHandles. true].
	new _ super copyRecordingIn: dict.
	new setVertices: vertices copy.
	hadHandles ifTrue: [self addHandles.  new addHandles].
	^ new