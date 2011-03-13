filterToNotCurrentAuthor
	"Filter down only to messages not stamped with my initials"

	| myInitials aMethod aTimeStamp |
	(myInitials := Utilities authorInitialsPerSe) ifNil: [^ self inform: 'No author initials set in this image'].
	self filterFrom:
		[:aClass :aSelector |
			(aClass notNil and: [aSelector notNil]) and:			
				[aMethod := aClass compiledMethodAt: aSelector ifAbsent: [nil].
				aMethod notNil and:
					[(aTimeStamp := Utilities timeStampForMethod: aMethod) isNil or:
						[(aTimeStamp beginsWith: myInitials) not]]]]