enabled: aBoolean
	"Set the value of enabled"

	enabled := aBoolean.
	self labelMorph ifNotNilDo: [:m |
		(m respondsTo: #enabled:) ifTrue: [
			m enabled: aBoolean]].
	self buttonMorph ifNotNilDo: [:m | m enabled: aBoolean].
	self changed: #enabled