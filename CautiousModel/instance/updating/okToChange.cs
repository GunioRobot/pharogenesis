okToChange
	Preferences cautionBeforeClosing ifFalse: [^ true].
	Sensor leftShiftDown ifTrue: [^ true].

	Beeper beep.
	^ self confirm: 'Warning!
If you answer "yes" here, this
window will disappear and
its contents will be lost!
Do you really want to do that?'

"CautiousModel new okToChange"