defaultClipboardInterpreter

	ClipboardInterpreterClass ifNil: [ClipboardInterpreterClass _ self currentPlatform class clipboardInterpreterClass].
	^ ClipboardInterpreterClass new.

