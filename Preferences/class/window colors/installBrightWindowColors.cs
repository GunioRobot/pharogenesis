installBrightWindowColors
	"Preferences installBrightWindowColors"
	| windowColorDict |
	(Parameters includesKey: #windowColors) ifFalse:
		[Parameters at: #windowColors put: IdentityDictionary new].
	windowColorDict _ Parameters at: #windowColors.

	#(	(Browser				lightGreen)
		(ChangeList				lightBlue)
		(ChangeSorter			lightBlue)
		(Debugger				lightRed)
		(DualChangeSorter		lightBlue)
		(FileContentsBrowser		tan)
		(FileList					lightMagenta)
		(MessageSet				lightBlue)
		(Object					white)
		(SelectorBrowser			lightCyan)
		(StringHolder			lightYellow)
		(TranscriptStream		lightOrange))

	do:
			[:pair |
				windowColorDict at: pair first put: (Color perform: pair last)]
