announce: anObject

	| ann |
	ann _ anObject asAnnouncement.
	subscriptions keysAndValuesDo:
		[:class :action |
		(ann isKindOf: class) ifTrue: [action valueWithArguments: {ann}]].
	^ ann