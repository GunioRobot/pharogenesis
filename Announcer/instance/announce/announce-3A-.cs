announce: anAnnouncement
	| announcement |
	announcement := anAnnouncement asAnnouncement.
	subscriptions ifNil: [ ^ announcement ].
	subscriptions keysAndValuesDo: [ :class :actions |
		(class handles: announcement) 
			ifTrue: [ actions valueWithArguments: (Array with: announcement) ] ].
	^ announcement