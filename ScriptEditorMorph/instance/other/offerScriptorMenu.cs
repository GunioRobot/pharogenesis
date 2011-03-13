offerScriptorMenu
	| aMenu result  aList lines title |
	self isAnonymous
		ifTrue:
			[aList _ #(
				('name and save this script'	renameScript)
				('destroy this script'			destroyScript)).
			title _ 'temporary script'.
			lines _ #()]
		ifFalse:
			[title _ scriptName asString.
			self isTextuallyCoded
				ifTrue:
					[title _ title, ' (textually coded)'.
					aList _ #(
						('revert to tile version...'		revertScriptVersion)
						('modify textual script'			editScriptTextually)
				"		('view all scripts'				browseScripts)"
						('destroy this script'				destroyScript)).
					lines _ #(2)]
				ifFalse:
					[aList _ #(
						('save this version'				saveScriptVersion)
						('revert to prior version...'		revertScriptVersion)
						('edit this script textually'		editScriptTextually)
					"	('view all scripts'				browseScripts)"
						('destroy this script'				destroyScript)).
					lines _ #(2 3)]].

	aMenu _ SelectionMenu labelList: (aList collect: [:pair | pair first]) lines: lines selections: (aList collect: [:pair | pair second]).
	result _ aMenu startUpWithCaption: title.
	result ifNotNil: [self perform: result]

"		('add parameter to this script'	addParameter)"