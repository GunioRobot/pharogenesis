filterToCurrentAuthor
	"Filter down only to messages with my initials as most recent author"

	| myInitials aMethod aTimeStamp |
	(myInitials _ Utilities authorInitialsPerSe) ifNil: [^ self inform: 'No author initials set in this image'].
	self filterFrom:
		[:aClass :aSelector |
			(aClass notNil and: [aSelector notNil]) and:			
				[aMethod _ aClass compiledMethodAt: aSelector ifAbsent: [nil].
				aMethod notNil and:
					[(aTimeStamp _ Utilities timeStampForMethod: aMethod) notNil and:
						[aTimeStamp beginsWith: myInitials]]]]