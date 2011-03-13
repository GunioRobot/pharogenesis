recordButton: buttonId actions: actionList condition: condition
	| button |
	button := buttons at: buttonId ifAbsent:[^self halt].
	(condition anyMask: 1) ifTrue:[
		button on: #mouseEnter sendAll: actionList.
	].
	(condition anyMask: 2) ifTrue:[
		button on: #mouseLeave sendAll: actionList.
	].
	(condition anyMask: 4) ifTrue:[
		button on: #mouseDown sendAll: actionList.
	].
	(condition anyMask: 8) ifTrue:[
		button on: #mouseUp sendAll: actionList.
	].
	(condition anyMask: 16) ifTrue:[
		button on: #mouseLeaveDown sendAll: actionList.
	].
	(condition anyMask: 32) ifTrue:[
		button on: #mouseEnterDown sendAll: actionList.
	].
	(condition anyMask: 64) ifTrue:[
		button on: #mouseUpOut sendAll: actionList.
	].
	(condition anyMask: 128) ifTrue:[
		button on: #mouseEnterDown sendAll: actionList.
	].
	(condition anyMask: 256) ifTrue:[
		button on: #mouseLeaveDown sendAll: actionList.
	].
