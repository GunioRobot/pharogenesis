checkForm: aStream
	| y x |

	self form notNil ifTrue: [^self].
	y _ self videoFrameHeight: aStream.
	x _ self videoFrameWidth: aStream.
	self form:  (Form extent: x@y depth: 32)
