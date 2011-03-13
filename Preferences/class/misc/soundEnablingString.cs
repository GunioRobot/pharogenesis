soundEnablingString
	^ self soundsEnabled
		ifFalse:
			['Turn sound on' translated]
		ifTrue:
			['Turn sound off' translated]