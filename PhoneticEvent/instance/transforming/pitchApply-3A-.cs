pitchApply: aBlock
	"Apply aBlock to the pitch points in the receiver."
	self hasPitch ifFalse: [^ self].
	pitchPoints _ pitchPoints collect: aBlock