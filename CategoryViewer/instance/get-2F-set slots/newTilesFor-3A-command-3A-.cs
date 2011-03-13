newTilesFor: aPlayer command: aSpec
	| ms argTile argArray sel |
	"Return universal tiles for a command.  Record who self is."

	sel _ aSpec second.
	aSpec size > 3 
		ifTrue: [argTile _ aPlayer tileForArgType: aSpec fourth inViewer: nil.
				argArray _ Array with: (aSpec fourth == #player 
					ifTrue: [argTile actualObject]
					ifFalse: [argTile literal]).	"default value for each type"
				sel == #colorSees ifTrue: [sel _ #color:sees:.  
							argArray _ argArray, argArray].	"two colors"
				sel == #isOverColor ifTrue: [sel _ #seesColor:].
				sel == #touchesA ifTrue: [sel _ #touchesA:].
		]
		ifFalse: [argArray _ #()].
	ms _ MessageSend receiver: aPlayer selector: sel arguments: argArray.
	^ ms asTilesIn: aPlayer class