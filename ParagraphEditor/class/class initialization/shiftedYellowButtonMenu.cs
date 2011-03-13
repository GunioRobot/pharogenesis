shiftedYellowButtonMenu
	| ww |
	"Answer the menu to be presented when the yellow button is pressed while the shift key is down"

^ SelectionMenu fromArray: (Array streamContents: [:strm | 
	strm nextPutAll: #(
		('set font... (k)'					offerFontMenu)
		('set style... (K)'					changeStyle)
		('set alignment...'				chooseAlignment)
		-								).
	(ww _ World) isMorph ifTrue: [
		(ww valueOfProperty: #universalTiles ifAbsent: [false]) ifTrue: [
			strm nextPutAll: #(
				('tiles from it'			selectionAsTiles))]].

	strm nextPutAll: #(
		('explain'						explain)
		('pretty print'					prettyPrint)
		('pretty print with color'		prettyPrintWithColor)
		('file it in'						fileItIn)
		('recognizer (r)'					recognizeCharacters)
		('spawn (o)'						spawn)
		-
		('definition of word'				wordDefinition)
		('verify spelling of word'		verifyWordSpelling)
"		('spell check it'					spellCheckIt)	"
		('translate it'					translateIt)
		('choose language'				languagePrefs)
		-
		('browse it (b)'					browseIt)
		('senders of it (n)'				sendersOfIt)
		('implementors of it (m)'		implementorsOfIt)
		('references to it (N)'			referencesToIt)
		('selectors containing it (W)'		methodNamesContainingIt)
		('method strings with it (E)'		methodStringsContainingit)
		('method source with it'			methodSourceContainingIt)
		-
		('save contents to file...'			saveContentsInFile)
		('send contents to printer'		sendContentsToPrinter)
		('printer setup'					printerSetup)
		-
		('special menu...'				presentSpecialMenu)
		('more...'						yellowButtonActivity))]).

