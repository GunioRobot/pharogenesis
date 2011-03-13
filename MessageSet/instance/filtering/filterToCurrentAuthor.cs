filterToCurrentAuthor
	"Filter down only to messages with my full name as most recent author"

	| myFullName aMethod aTimeStamp |
	(myFullName := Author fullNamePerSe) ifNil: [^ self inform: 'No author full name set in this image'].
	self filterFrom:
		[:aClass :aSelector |
			(aClass notNil and: [aSelector notNil]) and:			
				[aMethod := aClass compiledMethodAt: aSelector ifAbsent: [nil].
				aMethod notNil and:
					[(aTimeStamp := Utilities timeStampForMethod: aMethod) notNil and:
						[aTimeStamp beginsWith: myFullName]]]]