okToChange
	| parms |
	(parms _ Smalltalk at: #EToyParameters ifAbsent: [nil]) ifNotNil:
		[parms cautionBeforeClosing ifFalse: [^ true]].
	Sensor leftShiftDown ifTrue: [^ true].

	self beep.
	^ self confirm: 'Warning!
If you answer "yes" here, this
window will disappear and
its contents will be lost!
Do you really want to do that?'

"CautiousModel new okToChange"