showControlsString
	^(myControls notNil)
		ifTrue:[^'<on>camera controls'] 
		ifFalse:['<off>camera controls'].