fileContentsMenu: aMenu shifted: shifted
	"Construct aMenu to have items appropriate for the file browser's code pane, given the shift state provided"

	| shiftMenu services maybeLine extraLines |
	shifted ifTrue:
		[shiftMenu _ ParagraphEditor shiftedYellowButtonMenu.
		^ aMenu 
			labels: shiftMenu labelString 
			lines: shiftMenu lineArray
			selections: shiftMenu selections].
	fileName ifNotNil:
		[services _ OrderedCollection new.
		(#(briefHex briefFile needToGetBriefHex needToGetBrief) includes: brevityState) ifTrue:
			[services add: self serviceGet].
		(#(fullHex briefHex needToGetFullHex needToGetBriefHex) includes: brevityState) ifFalse:
			[services add: self serviceGetHex].
		(#(needToGetShiftJIS needToGetEUCJP needToGetCNGB needToGetEUCKR needToGetUTF8) includes: brevityState) ifFalse:
			[services add: self serviceGetEncodedText].
		maybeLine _ services size.
		(FileStream sourceFileSuffixes includes: self suffixOfSelectedFile) ifTrue:
			[services addAll:
				(self servicesFromSelectorSpecs:
					#(fileIntoNewChangeSet: fileIn: browseChangesFile: browseFile:))].

		extraLines _ OrderedCollection new.
		maybeLine > 0 ifTrue: [extraLines add: maybeLine].
		services size > maybeLine ifTrue: [extraLines add: services size].
		aMenu 
			addServices: services
			for: self fullName
			extraLines: extraLines].

	aMenu addList: {
			{'find...(f)' translated.		#find}.
			{'find again (g)' translated.		#findAgain}.
			{'set search string (h)' translated.	#setSearchString}.
			#-.
			{'do again (j)' translated.		#again}.
			{'undo (z)' translated.			#undo}.
			#-.
			{'copy (c)' translated.			#copySelection}.
			{'cut (x)' translated.			#cut}.
			{'paste (v)' translated.		#paste}.
			{'paste...' translated.			#pasteRecent}.
			#-.
			{'do it (d)' translated.		#doIt}.
			{'print it (p)' translated.		#printIt}.
			{'inspect it (i)' translated.		#inspectIt}.
			{'fileIn selection (G)' translated.	#fileItIn}.
			#-.
			{'accept (s)' translated.		#accept}.
			{'cancel (l)' translated.		#cancel}.
			#-.
			{'more...' translated.			#shiftedYellowButtonActivity}}.


	^ aMenu
