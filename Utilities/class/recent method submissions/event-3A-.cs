event: anEvent
	"Hook for SystemChangeNotifier"

	(anEvent isCommented and: [anEvent itemKind = SystemChangeNotifier classKind])
		ifTrue: [self noteMethodSubmission: #Comment forClass: anEvent item].
	((anEvent isAdded or: [anEvent isModified]) and: [anEvent itemKind = SystemChangeNotifier methodKind])
		ifTrue: [anEvent itemRequestor ifNotNil: [self noteMethodSubmission: anEvent itemSelector forClass: anEvent itemClass]].
	((anEvent isAdded or: [anEvent isModified]) and: [anEvent itemKind = SystemChangeNotifier methodKind]) ifTrue:[
		InMidstOfFileinNotification signal
			ifFalse: [Utilities changed: #recentMethodSubmissions].
	].