publishStyle: aSymbol forgetURL: aBoolean withRename: renameBoolean

	| w saveOwner primaryServer rename |

	w _ self world ifNil: [^Beeper beep].
	w setProperty: #SuperSwikiPublishOptions toValue: aSymbol.

	primaryServer _ w project primaryServerIfNil: [nil].
	rename _ ((primaryServer notNil
		and: [primaryServer acceptsUploads]) not)
		or: [renameBoolean].
	w setProperty: #SuperSwikiRename toValue: rename.

	saveOwner _ owner.
	self delete.
	[w project 
		storeOnServerShowProgressOn: self 
		forgetURL: aBoolean | rename]
		ensure: [saveOwner addMorphFront: self]