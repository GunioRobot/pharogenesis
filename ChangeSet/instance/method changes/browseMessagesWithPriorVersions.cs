browseMessagesWithPriorVersions
	"Open a message list browser on the new and changed methods in the receiver which have at least one prior version.  6/28/96 sw"

	| aList aSelector aClass |

	aList _ self changedMessageListAugmented select:
		[:msg |  Utilities setClassAndSelectorFrom: msg in: 
				[:cl :sl | aClass _ cl.  aSelector _ sl].
			(ChangeList versionCountForSelector: aSelector class: aClass) > 1].
	aList size > 0 ifFalse: [self inform: 'None!'.  ^ nil].
	Smalltalk browseMessageList: aList name: (self name, ' methods that have prior versions')