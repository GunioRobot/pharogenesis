removeMessage
	"If a message is selected, create a Confirmer so the user can verify that 
	the currently selected message should be removed from the system. If so, 
	remove it.  If the Preference 'confirmMethodRemoves' is set to false, the 
	confirmer is bypassed.
	1/15/96 sw: started to modify as per Dan's request"

	| message messageName confirmation |

	messageListIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].
	messageName _ self selectedMessageName.
	confirmation _ self selectedClassOrMetaClass confirmRemovalOf: messageName.
	confirmation == 3 ifTrue: [^ self].

	self selectedClassOrMetaClass removeSelector: self selectedMessageName.
	self messageListIndex: 0.
	self setClassOrganizer.  "In case organization not cached"
	self changed: #messageListChanged.

	confirmation == 2 ifTrue:
		[Smalltalk sendersOf: messageName]