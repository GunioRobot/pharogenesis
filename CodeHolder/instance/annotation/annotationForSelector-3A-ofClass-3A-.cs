annotationForSelector: aSelector ofClass: aClass
	"Provide a line of content for an annotation pane, representing information about the given selector and class"

	| stamp  sendersCount implementorsCount toShow aCategory separator aString aList versionsCount  aComment |

	toShow _ ReadWriteStream on: ''.
	separator _ ' ¥ '.
	self annotationRequests do:
		[:aRequest |
		(aRequest == #firstComment) ifTrue:
			[aComment _ aClass firstCommentAt:  aSelector.
			aComment isEmptyOrNil ifFalse:
				[toShow nextPutAll: (aComment, separator)]].

		(aRequest == #timeStamp) ifTrue:
			[stamp _ self timeStamp.
			toShow nextPutAll: (stamp size > 0
				ifTrue: [stamp, separator]
				ifFalse: ['no timeStamp', separator])].

		(aRequest == #messageCategory) ifTrue:
			[aCategory _ aClass organization categoryOfElement: aSelector.
			aCategory ifNotNil: "woud be nil for a method no longer present, e.g. in a recent-submissions browser"
				[toShow nextPutAll: aCategory, separator]].

		(aRequest == #sendersCount) ifTrue:
			[sendersCount _ (Smalltalk allCallsOn: aSelector) size.
			sendersCount _ sendersCount == 1
				ifTrue:
					['1 sender']
				ifFalse:
					[sendersCount printString, ' senders'].
			toShow nextPutAll: sendersCount, separator].

		(aRequest == #implementorsCount) ifTrue:
			[implementorsCount _ Smalltalk numberOfImplementorsOf: aSelector.
			implementorsCount _ implementorsCount == 1
				ifTrue:
					['1 implementor']
				ifFalse:
					[implementorsCount printString, ' implementors'].
			toShow nextPutAll: implementorsCount,  separator].

		(aRequest == #priorVersionsCount) ifTrue:
			[versionsCount _ VersionsBrowser versionCountForSelector: aSelector class: aClass.
			toShow nextPutAll: 
				((versionsCount > 1
					ifTrue:
						[versionsCount == 2 ifTrue:
							['1 prior version']
							ifFalse:
								[versionsCount printString, ' prior versions']]
					ifFalse:
						['no prior versions']), separator)].

		(aRequest == #priorTimeStamp) ifTrue:
			[stamp _ VersionsBrowser timeStampFor: aSelector class: aClass reverseOrdinal: 2.
			stamp ifNotNil: [toShow nextPutAll: 'prior time stamp: ', stamp, separator]].

		(aRequest == #recentChangeSet) ifTrue:
			[aString _ ChangeSorter mostRecentChangeSetWithChangeForClass: aClass selector: aSelector.
			aString size > 0 ifTrue: [toShow nextPutAll: aString, separator]].

		(aRequest == #allChangeSets) ifTrue:
			[aList _ ChangeSorter allChangeSetsWithClass: aClass selector: aSelector.
			aList size > 0
				ifTrue:
					[aList size = 1
						ifTrue:
							[toShow nextPutAll: 'only in change set ']
						ifFalse:
							[toShow nextPutAll: 'in change sets: '].
					aList do:
						[:aChangeSet | toShow nextPutAll: aChangeSet name, ' ']]
				ifFalse:
					[toShow nextPutAll: 'in no change set'].
			toShow nextPutAll: separator]].
		
	^ toShow contents