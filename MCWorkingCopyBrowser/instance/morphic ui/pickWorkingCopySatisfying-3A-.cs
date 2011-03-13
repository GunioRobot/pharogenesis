pickWorkingCopySatisfying: aBlock
	| copies index |
	copies := self workingCopies select: aBlock.
	copies isEmpty ifTrue: [ ^nil ].
	index := (PopUpMenu labelArray: (copies collect: [:ea | ea packageName]))
				startUpWithCaption: 'Package:'.
	^ index = 0 ifFalse: [ copies at: index]