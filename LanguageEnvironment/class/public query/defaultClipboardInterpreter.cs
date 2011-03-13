defaultClipboardInterpreter
	SmalltalkImage current platformName = 'Win32' ifTrue:[^UTF8ClipboardInterpreter new].
	ClipboardInterpreterClass ifNil: [ClipboardInterpreterClass := self currentPlatform class clipboardInterpreterClass].
	^ ClipboardInterpreterClass new.

