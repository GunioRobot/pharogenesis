shiftedYellowButtonMenu
	"Answer the menu to be presented when the yellow button is pressed while the shift key is down"

	^ SelectionMenu fromArray: {
		{'set font... (k)' translated.					#offerFontMenu}.
		{'set style... (K)' translated.					#changeStyle}.
		{'set alignment...' translated.				#chooseAlignment}.
		#-.
		{'explain' translated.						#explain}.
		{'pretty print' translated.					#prettyPrint}.
		{'pretty print with color' translated.		#prettyPrintWithColor}.
		{'file it in (G)' translated.					#fileItIn}.
		{'tiles from it' translated.					#selectionAsTiles}.
		{'recognizer (r)' translated.					#recognizeCharacters}.
		{'spawn (o)' translated.						#spawn}.
		#-.
		{'definition of word' translated.				#wordDefinition}.
		{'verify spelling of word' translated.		#verifyWordSpelling}.
		{'translate it' translated.						#translateIt}.
		{'choose language' translated.				#languagePrefs}.
		#-.
		{'browse it (b)' translated.					#browseIt}.
		{'senders of it (n)' translated.				#sendersOfIt}.
		{'implementors of it (m)' translated.		#implementorsOfIt}.
		{'references to it (N)' translated.			#referencesToIt}.
		#-.
		{'selectors containing it (W)' translated.	#methodNamesContainingIt}.
		{'method strings with it (E)' translated.	#methodStringsContainingit}.
		{'method source with it' translated.		#methodSourceContainingIt}.
		{'class names containing it' translated.	#classNamesContainingIt}.
		{'class comments with it' translated.		#classCommentsContainingIt}.
		{'change sets with it' translated.			#browseChangeSetsWithSelector}.
		#-.
		{'save contents to file...' translated.		#saveContentsInFile}.
		{'send contents to printer' translated.		#sendContentsToPrinter}.
		{'printer setup' translated.					#printerSetup}.
		#-.
		{'special menu...' translated.				#presentSpecialMenu}.
		{'more...' translated.							#yellowButtonActivity}.
	}
