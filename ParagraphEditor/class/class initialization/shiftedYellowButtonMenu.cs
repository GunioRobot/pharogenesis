shiftedYellowButtonMenu
	"Answer the menu to be presented when the yellow button is pressed while the shift key is down"

	^ MenuMorph fromArray: {
		
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
	"	#-.
		{'pretty print' translated.					#prettyPrint}.
		{'pretty print with color' translated.		#prettyPrintWithColor}.
		{'file it in (G)' translated.					#fileItIn}.
		#-.
		{'back...' translated.						#yellowButtonActivity}.
	"
	}
