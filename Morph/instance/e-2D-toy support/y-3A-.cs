y: aNumber
	"Set my vertical position relative to the bottom of the playfield or the world. Note that larger y values are closer to the top of the screen."

	| w offset newY aPlayfield |

	w _ self world.
	w ifNil: [^ self position: bounds left@aNumber].
	aPlayfield _ self referencePlayfield.
	offset _ self top - self referencePosition y.
	aPlayfield == nil
		ifTrue: [newY _ (w bottom - aNumber) + offset]
		ifFalse: [newY _ (aPlayfield bottom - aNumber) + offset].
	self position: bounds left@newY.
