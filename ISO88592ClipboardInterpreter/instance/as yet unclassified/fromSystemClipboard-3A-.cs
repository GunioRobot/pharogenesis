fromSystemClipboard: aString

	^ aString convertFromWithConverter: ISO88592TextConverter new.
