absorbUpdatesWriteFiles: doWrite zapNums: zapNumbers
	"Utilities absorbUpdatesWriteFiles: true zapNums: true"
	"Absorb all updates from the server of your choice, and write each update to a local file on your disk.  Chop off the sequence numbers, if indicated."
	| didWrite didZap |
	didWrite _ Preferences valueOfFlag: #updateSavesFile.
	didZap _ Preferences valueOfFlag: #updateRemoveSequenceNum.
	Preferences setPreference: #updateSavesFile toValue: doWrite.
	Preferences setPreference: #updateRemoveSequenceNum toValue: zapNumbers.
	self absorbUpdatesFromServer.
	Preferences setPreference: #updateSavesFile toValue: didWrite.
	Preferences setPreference: #updateRemoveSequenceNum toValue: didZap.
	