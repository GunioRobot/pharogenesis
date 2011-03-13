checkForm: aStream
	| y x |

	self form notNil ifTrue: [^self].
	y := self videoFrameHeight: aStream.
	x := self videoFrameWidth: aStream.
	self form:  (Form extent: x@y depth: 32)
