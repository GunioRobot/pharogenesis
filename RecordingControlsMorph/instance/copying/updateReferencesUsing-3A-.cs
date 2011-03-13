updateReferencesUsing: aDictionary
	"Copy my recorder."

	super updateReferencesUsing: aDictionary.
	recorder _ SoundRecorder new.
