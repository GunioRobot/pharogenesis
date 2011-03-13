changed: what
	"Respond to an external change.  By tck, mid-1991.
	 3/1/96 sw: present message lists in sorted order"

	| cls |
	what == #set ifTrue: [^ self launch].
	what == #class ifTrue:
		[self verifyLabel.
		(cls _ classList selectedClassOrMetaClass) == nil
			ifFalse: [messageList list:
					((myChangeSet selectorsInClass: cls name) collect: 
						[:each | each printString]) asSortedCollection]
			ifTrue: [messageList list: #()].
		^ self].

	what == #message ifTrue:
		[self setContents.
		^ super changed: #editMessage].
	super changed: what