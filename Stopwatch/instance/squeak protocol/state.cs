state

	^ state ifNil: [ state := #suspended ]
