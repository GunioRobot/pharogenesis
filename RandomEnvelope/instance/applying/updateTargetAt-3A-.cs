updateTargetAt: mSecs
	"Send my updateSelector to the given target object with the value of this envelope at the given number of milliseconds from its onset. Answer true if the value changed."

	| r |
	r _ rand next.
	r > 0.5
		ifTrue: [
			currValue _ currValue + delta.
			currValue > highLimit ifTrue: [currValue _ highLimit]]
		ifFalse: [
			currValue _ currValue - delta.
			currValue < lowLimit ifTrue: [currValue _ lowLimit]].
	currValue = lastValue ifTrue: [^ false].
	((target == nil) or: [updateSelector == nil]) ifTrue: [^ false].
	target
		perform: updateSelector
		with: scale * currValue.
	lastValue _ currValue.
	^ true
