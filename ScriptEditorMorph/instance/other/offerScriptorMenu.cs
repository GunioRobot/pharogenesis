offerScriptorMenu
	"Put up a menu in response to the user's clicking in the menu-request area of the scriptor's heaer"

	| aMenu  count |

	self modernize.
	aMenu _ MenuMorph new defaultTarget: self.
	aMenu addTitle: scriptName asString.
	count _ self savedTileVersionsCount.

	self showingMethodPane
		ifFalse:				"currently showing tiles"
			[aMenu add: 'show code textually' action: #showSourceInScriptor.
			count > 0 ifTrue: 
				[aMenu add: 'revert to tile version...' action:	 #revertScriptVersion].
			aMenu add: 'save this version'	action: #saveScriptVersion]

		ifTrue:				"current showing textual source"
			[count >= 1 ifTrue:
				[aMenu add: 'revert to tile version' action: #revertToTileVersion].
			aMenu add: 'make tiles from this code' action: #recreateTileVersion].
	Preferences noviceMode ifFalse: ["just for now, not for kids"
		aMenu add: 'use new universal tiles' action: #useNewTiles].
			

	aMenu addList: #(
		-
		('destroy this script'					destroyScript)
		('rename this script'					renameScript)
		-
		('fires per tick...'					chooseFrequency)
		('explain status alternatives' 		explainStatusAlternatives)
		('hand me a tile for self'			tileForSelf)
		('edit balloon help for this script'	editMethodDescription)
		('button to fire this script'			tearOfButtonToFireScript)
		 ).

	aMenu popUpInWorld: self currentWorld.

	"		('add parameter to this script'	addParameter)"
