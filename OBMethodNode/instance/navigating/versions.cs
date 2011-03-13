versions
	^ (OBMethodVersion scan: self sourceFiles from: self sourcePointer)
		collect: [:ea | OBMethodVersionNode on: ea]