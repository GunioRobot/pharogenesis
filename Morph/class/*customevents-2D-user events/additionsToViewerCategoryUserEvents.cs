additionsToViewerCategoryUserEvents
	"Answer viewer additions relating to user-defined events for the 'scripting' category"

	^(Preferences allowEtoyUserCustomEvents)
		ifTrue: [ #(scripting (
			(command triggerCustomEvent: 'trigger a user-defined (global) event' CustomEvents)
			(slot triggeringObject 'the object that is triggering an event, either user-defined or pre-defined' Player readOnly Player getTriggeringObject unused unused)
		)) ]
		ifFalse: [  #(scripting (
			(slot triggeringObject 'the object that is triggering an event, either user-defined or pre-defined' Player readOnly Player getTriggeringObject unused unused)))  ]
