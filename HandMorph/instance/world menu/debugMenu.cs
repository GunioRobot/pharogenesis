debugMenu
	"Build the scripting menu for the world."
	| menu |
	menu _ (MenuMorph entitled: 'debug...') defaultTarget: self.
	menu addStayUpItem.
	menu add: 'inspect world' target: owner action: #inspect.
	menu add: 'explore world' target: owner action: #explore.
	menu add: 'inspect model' action: #inspectWorldModel.
	"menu add: 'talk to world...' action: #typeInMessageToWorld."
	menu add: 'start MessageTally' action: #startMessageTally.
	menu add: 'start/browse MessageTally' action: #startThenBrowseMessageTally.
	menu addLine.
	"(self hasProperty: #errorOnDraw) ifTrue:  Later make this come up only when needed."
		menu add: 'start drawing again' target: owner action: #resumeAfterDrawError.
		menu add: 'start stepping again' target: owner action: #resumeAfterStepError.
	menu addLine.
	menu add: 'call #tempCommand' action: #callTempCommand.
	menu add: 'define #tempCommand' action: #defineTempCommand.
	^ menu
