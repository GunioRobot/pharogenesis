shiftedYellowButtonMenu
	"Answer the menu to be presented when the yellow button is pressed while the shift key is down"

	^ SelectionMenu fromArray: #(
		('set font... (k)'					offerFontMenu)
		('set style... (K)'					changeStyle)
		('set alignment...'				chooseAlignment)
		-
		('explain'						explain)
		('pretty print'					prettyPrint)
		('pretty print with color'		prettyPrintWithColor)
		('file it in'						fileItIn)
		('recognizer (r)'					recognizeCharacters)
		('spawn (o)'						spawn)
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
		('more...'						yellowButtonActivity))