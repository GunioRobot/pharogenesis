openChangeSetBrowser
	"Open a ChangeSet browser on the current change set"

	Smalltalk isMorphic
		ifFalse:
			[self browseChangeSet]  "msg-list browser only"
		ifTrue:
			[(ChangeSetBrowser new myChangeSet: myChangeSet) openAsMorph]