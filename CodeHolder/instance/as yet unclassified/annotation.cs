annotation
	"Provide a line of annotation material for a middle pane."

	| stamp aMessage sendersCount implementorsCount toShow aCategory separator aString aList versionsCount |

	(aMessage _ self selectedMessageName)
		ifNil: [^ '------'].
	toShow _ ReadWriteStream on: ''.
	separator _ ' ¥ '.
	self annotationRequests do:
		[:aRequest |
		(aRequest == #timeStamp) ifTrue:
			[stamp _ self timeStamp.
			toShow nextPutAll: (stamp size > 0
				ifTrue: [stamp, separator]
				ifFalse: ['no timeStamp', separator])].

		(aRequest == #messageCategory) ifTrue:
			[aCategory _ self selectedClassOrMetaClass organization categoryOfElement: self selectedMessageName.
			aCategory ifNotNil: "woud be nil for a method no longer present, e.g. in a recent-submissions browser"
				[toShow nextPutAll: aCategory, separator]].

		(aRequest == #sendersCount) ifTrue:
			[sendersCount _ (Smalltalk allCallsOn: aMessage) size.
			sendersCount _ sendersCount == 1
				ifTrue:
					['1 sender']
				ifFalse:
					[sendersCount printString, ' senders'].
			toShow nextPutAll: sendersCount, separator].

		(aRequest == #implementorsCount) ifTrue:
			[implementorsCount _ (Smalltalk allImplementorsOf: aMessage) size.
			implementorsCount _ implementorsCount == 1
				ifTrue:
					['1 implementor']
				ifFalse:
					[implementorsCount printString, ' implementors'].
			toShow nextPutAll: implementorsCount,  separator].

		(aRequest == #priorVersionsCount) ifTrue:
			[versionsCount _ VersionsBrowser versionCountForSelector: self selectedMessageName class: self selectedClassOrMetaClass.
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
			[stamp _ VersionsBrowser timeStampFor: self selectedMessageName class: self selectedClassOrMetaClass reverseOrdinal: 2.
			stamp ifNotNil: [toShow nextPutAll: 'prior time stamp: ', stamp, separator]].

		(aRequest == #recentChangeSet) ifTrue:
			[aString _ ChangeSorter mostRecentChangeSetWithChangeForClass: self selectedClassOrMetaClass selector: self selectedMessageName.
			aString size > 0 ifTrue: [toShow nextPutAll: aString, separator]].

		(aRequest == #allChangeSets) ifTrue:
			[aList _ ChangeSorter allChangeSetsWithClass: self selectedClassOrMetaClass selector: self selectedMessageName.
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