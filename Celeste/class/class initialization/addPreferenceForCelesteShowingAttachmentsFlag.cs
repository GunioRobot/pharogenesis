addPreferenceForCelesteShowingAttachmentsFlag
	"Assure the existence of a preference governing the showing of the celeste attachments flag"

	Preferences preferenceAt: #celesteShowsAttachmentsFlag ifAbsent:
		[Preferences
			addPreference: #celesteShowsAttachmentsFlag
			category: #general
			default: false
			balloonHelp: 'If true, Celeste (e-mail reader) annotates messages in it''s list that have attachments.  This is a performance hit and by default is off.']