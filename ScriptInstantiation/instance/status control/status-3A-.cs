status: newStatus
	| stati actualMorph |
	actualMorph _ player costume renderedMorph.
	stati _ ScriptingSystem standardEventStati.
	(stati includes: status) ifTrue:[
		actualMorph on: status send: nil to: nil.  			"remove old link in event handler"
		status == #mouseStillDown ifTrue:[actualMorph on: #mouseDown send: nil to: nil]].
	(stati includes: newStatus) ifTrue:[
		actualMorph on: newStatus send: selector to: player.  "establish new link in evt handler"
		newStatus == #mouseStillDown ifTrue:[actualMorph on: #mouseDown send: selector to: player]].
	status _ newStatus.
	self flag: #arNote.
	self flag: #workaround. "Code below was in #chooseTriggerFrom: which did not reflect status changes from other places (e.g., the stepping/pause buttons). It is not clear why this is necessary though - theoretically, any morph should step when it has a player but alas! something is broken and I have no idea why and where."
	status == #ticking ifTrue: [player costume arrangeToStartStepping].
