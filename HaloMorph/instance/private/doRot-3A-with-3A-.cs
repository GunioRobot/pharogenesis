doRot: evt with: rotHandle
	"Update the rotation of my target if it is rotatable.  Keep the relevant command object up to date."

	| degrees |
	evt hand obtainHalo: self.
	degrees _ (evt cursorPoint - (target pointInWorld: target referencePosition)) degrees.
	degrees _ degrees - angleOffset degrees.
	degrees _ degrees detentBy: 10.0 atMultiplesOf: 90.0 snap: false.
	degrees = 0.0
		ifTrue: [rotHandle color: Color lightBlue]
		ifFalse: [rotHandle color: Color blue].
	rotHandle submorphsDo:
		[:m | m color: rotHandle color makeForegroundColor].
	self removeAllHandlesBut: rotHandle.
	self showingDirectionHandles ifFalse:
		[self showDirectionHandles: true addHandles: false].
	self addDirectionHandles.

	target rotationDegrees: degrees.

	rotHandle position: evt cursorPoint - (rotHandle extent // 2).
	(self valueOfProperty: #commandInProgress) ifNotNilDo:
		[:cmd | "Update the final rotation"
		cmd redoTarget: target selector: #rotationDegrees: argument: degrees].
	self layoutChanged