preserveStateDuring: aBlock
	"Preserve the full canvas state during the execution of aBlock.
	Note: This does *not* include the state in the receiver (e.g., foundMorph)."
	| tempCanvas |
	tempCanvas := self copy.
	aBlock value: tempCanvas.
	foundMorph := tempCanvas foundMorph.