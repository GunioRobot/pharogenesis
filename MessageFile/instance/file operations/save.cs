save
	"Make sure the message file is flushed to disk. This is NOT atomic because MessageFiles can get large and there might not be enough disk space to save them atomically. Besides, it would be very slow."

	file ifNil: [^ self].
	file ensureOpen.
	file closed  "Will still be closed if no file present"
		ifFalse: [file setToEnd; close; reopen].
