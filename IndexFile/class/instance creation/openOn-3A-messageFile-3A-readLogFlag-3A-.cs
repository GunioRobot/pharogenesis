openOn: fileName messageFile: messageFile readLogFlag: readLogFlag 
	"Answer a new instance of me for the given message file, backed by the 
	file with the given name."
	^ (super on: fileName)
		messageFile: messageFile;
		open