soundEnablingString
	^ self soundsEnabled
		ifFalse:
			['turn sound on']
		ifTrue:
			['turn sound off']