fileOut
	"File out the receiver, to a file whose name is a function of the  
	change-set name and either of the date & time or chosen to have a  
	unique numeric tag, depending on the preference  
	'changeSetVersionNumbers'"
	| slips nameToUse internalStream |
	self checkForConversionMethods.
	ChangeSet promptForDefaultChangeSetDirectoryIfNecessary.
	nameToUse := Preferences changeSetVersionNumbers
				ifTrue: [self defaultChangeSetDirectory nextNameFor: self name extension: FileStream cs]
				ifFalse: [self name , FileDirectory dot , Utilities dateTimeSuffix, FileDirectory dot , FileStream cs].
	nameToUse := self defaultChangeSetDirectory fullNameFor: nameToUse.
	Cursor write showWhile: [
			internalStream _ WriteStream on: (String new: 10000).
			internalStream header; timeStamp.
			self fileOutPreambleOn: internalStream.
			self fileOutOn: internalStream.
			self fileOutPostscriptOn: internalStream.
			internalStream trailer.

			FileStream writeSourceCodeFrom: internalStream baseName: (nameToUse copyFrom: 1 to: nameToUse size - 3) isSt: false useHtml: false.
	].
	Preferences checkForSlips
		ifFalse: [^ self].
	slips := self checkForSlips.
	(slips size > 0
			and: [(PopUpMenu withCaption: 'Methods in this fileOut have halts
or references to the Transcript
or other ''slips'' in them.
Would you like to browse them?' chooseFrom: 'Ignore\Browse slips')
					= 2])
		ifTrue: [self systemNavigation browseMessageList: slips name: 'Possible slips in ' , name]