findDuplicates
	"MailDB someInstance findDuplicates"
	| msgsAtTime duplicates msgsBySize similarMessages textCache first second text1 text2 |
	duplicates _ PluggableSet integerSet.
	msgsAtTime _ ((self messagesIn: '.all.')
				collect: [:e | indexFile at: e])
				groupBy: [:e | e time]
				having: [:arr | arr size > 1].
	msgsAtTime
		associationsDo: 
			[:assoc | 
			msgsBySize _ assoc value groupBy: [:e | e textLength]
						having: [:arr | arr size > 1].
			msgsBySize
				associationsDo: 
					[:assoc2 | 
					similarMessages _ assoc2 value.
					textCache _ PluggableDictionary integerDictionary.
					similarMessages combinations: 2
						atATimeDo: 
							[:each | 
							first _ each first.
							second _ each second.
							((first likelyEqual: second)
								and: 
									[text1 _ textCache at: first msgID ifAbsentPut: [(self getMessage: first msgID) bodyText].
									text2 _ textCache at: second msgID ifAbsentPut: [(self getMessage: second msgID) bodyText].
									text1 = text2])
								ifTrue: [duplicates add: second msgID]]]].
	^ duplicates asArray