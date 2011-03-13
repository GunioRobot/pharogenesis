shiftedYellowButtonMenu
	^ {
		{'explain' translated.						#explain}.
		#-.
		{'selectors containing it (W)' translated.		#methodNamesContainingIt}.
		{'method strings with it (E)' translated.		#methodStringsContainingit}.
		{'method source with it' translated.			#methodSourceContainingIt}.
		{'class names containing it' translated.		#classNamesContainingIt}.
		{'class comments with it' translated.			#classCommentsContainingIt}.
		{'change sets with it' translated.				#browseChangeSetsWithSelector}.
		#-.
		{'save contents to file...' translated.			#saveContentsInFile}.
		#-.
		{'more...' translated.							#yellowButtonActivity}.
	}
