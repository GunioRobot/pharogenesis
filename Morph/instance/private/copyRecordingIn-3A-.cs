copyRecordingIn: dict
	"Recursively copy this entire composite morph, recording the correspondence between old and new morphs in the given dictionary. This dictionary will be used to update intra-composite references in the copy.  See updateReferencesUsing:
	Rules:  All morphs being copied must be in the submorph&owner hierarchy of the first object being copied.  Any morph this is NOT in submorph&owner hierarchy, and is only held by an inst var or by an array, etc., MUST be copied by an override of this method for the class of the instance that holds onto it.  This is really hard to obey!!!"

	| new |
	new _ self copy.
	dict at: self put: new.
	submorphs size > 0 ifTrue: [
		new privateSubmorphs:
			(submorphs collect: [:m |
				(m copyRecordingIn: dict) privateOwner: new])].
	new copyPropertiesFrom: self dict: dict.
	^ new