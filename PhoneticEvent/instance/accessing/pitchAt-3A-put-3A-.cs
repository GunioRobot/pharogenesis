pitchAt: time put: aNumber
	"Set the pitch of the receiver at a given time."
	pitchPoints isNil ifTrue: [pitchPoints _ Array with: time @ aNumber. ^ self].
	pitchPoints _ pitchPoints copyWith: time @ aNumber