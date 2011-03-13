okToChange
	self isUnlocked ifTrue: [^ true].
	self changed: #wantToChange.  "Solicit cancel from view"
	^ self isUnlocked