pitchAt: time put: aNumber
	"Set the pitch of the receiver at a given time."
	pitchPoints isNil ifTrue: [pitchPoints := Array with: time @ aNumber. ^ self].
	pitchPoints := pitchPoints copyWith: time @ aNumber