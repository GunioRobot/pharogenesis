okayToAccept
	"Answer whether it is okay to accept the receiver's input"

	| ok aClass reply |
	(ok := super okayToAccept) ifTrue:
		[((aClass := self selectedClassOrMetaClass) ~~ targetClass) ifTrue:
			[reply := UIManager default chooseFrom: 
	{'okay, no problem'. 
	'cancel - let me reconsider'. 
	'compile into ', targetClass name, ' instead'.
	'compile into a new uniclass'} title:
'Caution!  This would be
accepted into class ', aClass name, '.
Is that okay?' .
			reply = 1 ifTrue: [^ true].
			reply ~~ 2 ifTrue:
				[self notYetImplemented].
			^ false]].
	^ ok