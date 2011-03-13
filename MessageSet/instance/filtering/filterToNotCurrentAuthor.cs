filterToNotCurrentAuthor
	"Filter down only to messages not stamped with my initials"

	| myFullName aMethod aTimeStamp |
	(myFullName := Author fullNamePerSe) ifNil: [^ self inform: 'No author full name set in this image'].
	self filterFrom:
		[:aClass :aSelector |
			(aClass notNil and: [aSelector notNil]) and:			
				[aMethod := aClass compiledMethodAt: aSelector ifAbsent: [nil].
				aMethod notNil and:
					[(aTimeStamp := Utilities timeStampForMethod: aMethod) isNil or:
						[(aTimeStamp beginsWith: myFullName) not]]]]