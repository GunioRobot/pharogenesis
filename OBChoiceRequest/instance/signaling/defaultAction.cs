defaultAction
	^ values 
		at: ((PopUpMenu labelArray: labels lines: lines) startUpWithCaption: prompt)
		ifAbsent: [nil]