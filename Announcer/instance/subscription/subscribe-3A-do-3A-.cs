subscribe: anAnnouncementClass do: aValuable 
	| actions |
	subscriptions ifNil: [ subscriptions := IdentityDictionary new ].
	actions := subscriptions at: anAnnouncementClass ifAbsent: [ ActionSequence new ].
	subscriptions at: anAnnouncementClass put: (actions copyWith: aValuable).
	^ aValuable