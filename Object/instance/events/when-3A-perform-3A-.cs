when: anEventSymbol perform: aMessageSend
	"Register aMessageSend as action for anEventSymbol."

	| events |
	(events _ self myEvents) ifNil:
		[self myEvents: (events _ IdentityDictionary new)].
	(events
		at: anEventSymbol 
		ifAbsentPut: [Set new]) add: aMessageSend