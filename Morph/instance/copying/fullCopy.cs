fullCopy
	"Produce a copy of me with my entire tree of submorphs.  Morphs
mentioned more than once are all directed to a single new copy.  Simple
inst vars are not copied, so you must override to copy Arrays, etc.  "

	| dict new |
	dict _ IdentityDictionary new: 1000.
	new _ self copyRecordingIn: dict.
	new allMorphsDo: [:m | m updateReferencesUsing: dict].
	^ new