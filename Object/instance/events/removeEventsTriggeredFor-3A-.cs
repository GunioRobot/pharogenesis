removeEventsTriggeredFor: anObject
	"Remove all that events trigged by the receiver which would have
	been send to anObject."

	| events |
	events _ self myEvents ifNil: [^ self].
	events copy keysAndValuesDo:
		[:evtSym :msgSendSet |
		| newSet |
		newSet _ msgSendSet reject: [:each | each receiver == anObject].
		msgSendSet size = newSet size ifFalse:
			[newSet isEmpty
				ifTrue: [events removeKey: evtSym]
				ifFalse: [events at: evtSym put: newSet]]].
	self myEvents: (events isEmpty ifFalse: [events])