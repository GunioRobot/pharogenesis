okayToAccept
	"Answer whether it is okay to accept the receiver's input"

	| ok aClass reply |
	(ok _ super okayToAccept) ifTrue:
		[((aClass _ self selectedClassOrMetaClass) ~~ targetClass) ifTrue:
			[reply _ PopUpMenu withCaption:
'Caution!  This would be
accepted into class ', aClass name, '.
Is that okay?' chooseFrom: 
	{'okay, no problem'. 
	'cancel - let me reconsider'. 
	'compile into ', targetClass name, ' instead'.
	'compile into a new uniclass'}.
			reply = 1 ifTrue: [^ true].
			reply ~~ 2 ifTrue:
				[self notYetImplemented].
			^ false]].
	^ ok