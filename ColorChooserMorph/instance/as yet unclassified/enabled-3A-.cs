enabled: aBoolean
	"Set the enabled state of the receiver."

	enabled := aBoolean.
	self contentMorph ifNotNilDo: [:m | m enabled: aBoolean].
	self changed: #enabled