getVolume
	"answer the receiver's movie position"
	^ self volumeSlider isNil ifFalse:[self volumeSlider getScaledValue] ifTrue:[0.0]