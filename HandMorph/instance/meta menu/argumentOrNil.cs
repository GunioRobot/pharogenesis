argumentOrNil
	"Answer the root of the front-most morph under the cursor. If the cursor is not over any morph, answer nil."

	owner submorphsDo:
		[:m | ((m fullContainsPoint: targetOffset) and: [m isLocked not]) ifTrue: [^ m]].
	^ nil
