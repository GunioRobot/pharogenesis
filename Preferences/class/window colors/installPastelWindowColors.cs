installPastelWindowColors
	"Preferences installPastelWindowColors"
	| windowColorDict |
	(Parameters includesKey: #windowColors) ifFalse:
		[Parameters at: #windowColors put: IdentityDictionary new].
	windowColorDict _ Parameters at: #windowColors.

	#(	(Browser				paleGreen)
		(ChangeList				paleBlue)
		(ChangeSorter			paleBlue)
		(Debugger				veryPaleRed)
		(DualChangeSorter		paleBlue)
		(FileContentsBrowser		paleTan)
		(FileList					paleMagenta)
		(MessageSet				paleBlue)
		(Object					white)
		(SelectorBrowser			palePeach)
		(StringHolder			paleYellow)
		(TranscriptStream		paleOrange))

	do:
			[:pair |
				windowColorDict at: pair first put: (Color perform: pair last)]
