offerScriptorMenu
	| aMenu result  aList lines title |
	self isAnonymous
		ifTrue:
			[^ self inform: 'ancient structure!
please modernize!']
		ifFalse:
			[title _ scriptName asString.
			self isTextuallyCoded
				ifTrue:
					[title _ title, ' (textually coded)'.
					aList _ #(
						('revert to tile version...'		revertScriptVersion)
						('modify textual script'			editScriptTextually)
						('stand-alone script pane'		makeIsolatedCodePane)
						('fires per tick...'				chooseFrequency)
				"		('view all scripts'				browseScripts)"
						('destroy this script'				destroyScript)
						('rename this script'				renameScript)
						('explain status alternatives' 	explainStatusAlternatives)
						('button to fire this script'		tearOfButtonToFireScript)).
					lines _ #(3 4 6)]
				ifFalse:
					[aList _ #(
						('save this version'				saveScriptVersion)
						('revert to prior version...'		revertScriptVersion)
						('edit this script textually'		editScriptTextually)
						('stand-alone script pane'		makeIsolatedCodePane)
						('fires per tick...'				chooseFrequency)
					"	('view all scripts'				browseScripts)"
						('destroy this script'				destroyScript)
						('rename this script'				renameScript)
						('explain status alternatives' 	explainStatusAlternatives)
						('button to fire this script'		tearOfButtonToFireScript)).
					lines _ #(4 5 7)]].

	aMenu _ SelectionMenu labelList: (aList collect: [:pair | pair first]) lines: lines selections: (aList collect: [:pair | pair second]).
	result _ aMenu startUpWithCaption: title.
	result ifNotNil: [self perform: result]

"		('add parameter to this script'	addParameter)"