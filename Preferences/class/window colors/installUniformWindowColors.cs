installUniformWindowColors
	"Preferences installUniformWindowColors"
	| windowColorDict |
	(Parameters includesKey: #windowColors) ifFalse:
		[Parameters at: #windowColors put: IdentityDictionary new].
	windowColorDict _ Parameters at: #windowColors.

	#(	(Browser				white)
		(ChangeList				white)
		(ChangeSorter			white)
		(Debugger				white)
		(DualChangeSorter		white)
		(FileContentsBrowser		white)
		(FileList					white)
		(MessageSet				white)
		(Object					white)
		(SelectorBrowser			white)
		(StringHolder			white)
		(TranscriptStream		white))

	do:
			[:pair |
				windowColorDict at: pair first put: (Color perform: pair last)]
