initialize
	"initialize the receiver"
	(TheWorldMenu respondsTo: #registerOpenCommand:)
		ifTrue: [""
			TheWorldMenu registerOpenCommand: {'Language Editor'. {self. #openOnDefault}}.
			TheWorldMenu registerOpenCommand: {'Language Editor for...'. {self. #open}}]