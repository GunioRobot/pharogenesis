doRot: evt with: rotHandle
	"Update the rotation of my target if it is rotatable."

	| degrees |
	degrees _ (evt cursorPoint - (target pointInWorld: target referencePosition)) degrees.
	degrees _ degrees - angleOffset degrees.
	degrees _ degrees detentBy: 10.0 atMultiplesOf: 90.0 snap: false.
	degrees = 0.0
		ifTrue: [rotHandle color: Color lightBlue]
		ifFalse: [rotHandle color: Color blue].
	rotHandle submorphsDo:
		[:m | m color: rotHandle color makeForegroundColor].
	((innerTarget isKindOf: SketchMorph) and: [innerTarget rotationStyle == #normal]) ifTrue:
		[self removeAllHandlesBut: rotHandle.
		target player ifNotNil: [self addDirectionShaft]].

	target rotationDegrees: degrees.

	rotHandle position: evt cursorPoint - (rotHandle extent // 2).
	self layoutChanged