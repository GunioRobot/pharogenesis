removeMessage
	"Remove the selected message from the system"
	| messageName confirmation |

	self okToChange ifFalse: [^ self].  "currently it's always ok"
	messageName _ self selectedMessageName.
	confirmation _ self selectedClassOrMetaClass confirmRemovalOf: messageName.
	confirmation ~~ 3 ifTrue: 
		[self selectedClassOrMetaClass removeSelector: messageName.
		self launch.
		(parent other: self) launch]