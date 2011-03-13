checkForAlienAuthorship
	"Check to see if there are any methods in the receiver that have author initials other than that of the current author, and open a browser on all found"

	| aList initials |
	(initials _ Utilities authorInitialsPerSe) ifNil: [^ self inform: 'No author initials set in this image'].
	(aList _ self methodsWithInitialsOtherThan: initials) size > 0
		ifFalse:
			[^ self inform: 'All methods in "', self name, '"
have authoring stamps which start with "', initials, '"']
		ifTrue:
			[Smalltalk browseMessageList: aList name: 'methods in "', self name, '" whose authoring stamps do not start with "', initials, '"']