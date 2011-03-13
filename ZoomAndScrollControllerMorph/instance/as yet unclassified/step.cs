step

	| delta halfDW action |

	(self valueOfProperty: #currentCameraVersion ifAbsent: [0]) = 
							self currentCameraVersion ifFalse: [
		self patchOldVersion1.
		self setProperty: #currentCameraVersion toValue: self currentCameraVersion.
	].
	super step.
	self doProgrammedMoves.

	(currentKeyDown ifNil: [#()]) do: [ :each |
		action _ upDownCodes at: each ifAbsent: [#fugeddaboutit].
		action == #in ifTrue: [
			target scaleImageBy: -10.
		].
		action == #out ifTrue: [
			target scaleImageBy: 10.
		].
		action == #up ifTrue: [
			target tiltImageBy: -20.
		].
		action == #down ifTrue: [
			target tiltImageBy: 20.
		].
	].
	mouseMovePoint ifNil: [^self].
	mouseDownPoint ifNil: [^self].
	target ifNil: [^self].
	halfDW _ self deadZoneWidth // 2.
	delta _ mouseMovePoint - mouseDownPoint.
	delta x abs <= halfDW ifTrue: [delta _ 0@delta y].
	delta y abs <= halfDW ifTrue: [delta _ delta x@0].
	
	target panImageBy: delta x.



