flushEvents
	"Object flushEvents"
	| msgSet |
	self actionMaps keysAndValuesDo:[:rcvr :evtDict| rcvr ifNotNil:[
		"make sure we don't modify evtDict while enumerating"
		evtDict keys do:[:evtName|
			msgSet _ evtDict at: evtName ifAbsent:[nil].
			(msgSet == nil) ifTrue:[rcvr removeActionsForEvent: evtName]]]].
	EventManager actionMaps finalizeValues. 