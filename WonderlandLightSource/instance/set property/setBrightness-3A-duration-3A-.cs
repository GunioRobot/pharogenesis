setBrightness: aNumber duration: aDuration
	"Sets the brightness of the light between 0 and 1 by varying the color of the light."

	| r g b scale currentBrightness |

	"First verify our arguments"
	[ WonderlandVerifier Verify0To1Number: aNumber ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not the brightness to make the light because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyDuration: aDuration ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the duration to use for changing the brightness of the light because ', msg.
			^ nil ].

	currentBrightness _ self getBrightness.

	(currentBrightness = 0)
		ifTrue: [
					r _ aNumber.
					g _ aNumber.
					b _ aNumber.
				]
		ifFalse: [
					scale _ (aNumber / (self getBrightness)).
					r _ (myColor red) * scale.
					g _ (myColor green) * scale.
					b _ (myColor blue) * scale.
				].

	"Our parameters check out, so run the animation"
	self setColor: { r. g. b } duration: aDuration.
