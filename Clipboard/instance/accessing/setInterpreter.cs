setInterpreter

	interpreter _ LanguageEnvironment defaultClipboardInterpreter.
	interpreter ifNil: [
		"Should never be reached, but just in case."
		interpreter _ NoConversionClipboardInterpreter new].
