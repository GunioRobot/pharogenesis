browseMessagesWithPriorVersions
	"Open a message list browser on the new and changed methods in the receiver which have at least one prior version.  6/28/96 sw"

	| aList |

	aList _ self 
		messageListForChangesWhich: [ :aClass :aSelector |
			(VersionsBrowser versionCountForSelector: aSelector class: aClass) > 1
		]
		ifNone: [^self inform: 'None!'].
	self systemNavigation 
		browseMessageList: aList 
		name: self name, ' methods that have prior versions'