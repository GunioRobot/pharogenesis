openOn: fileName messageFile: messageFile
	"Answer a new instance of me for the given message file, backed by the file with the given name."

	^(super new) openOn: fileName messageFile: messageFile