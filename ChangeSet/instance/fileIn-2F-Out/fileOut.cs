fileOut
	"File out the receiver, to a file whose name is a function of the change-set name and either of the date & time or chosen to have a unique numeric tag, depending on the preference 'sequentialChangeSetRevertableFileNames'"

	| file slips nameToUse |
	self checkForConversionMethods.
	nameToUse _ Preferences changeSetVersionNumbers
		ifTrue:
			[FileDirectory default nextNameFor: self name extension: 'cs']
		ifFalse:
			[(self name, FileDirectory dot, Utilities dateTimeSuffix, 
				FileDirectory dot, 'cs') asFileName].
	Cursor write showWhile:
		[file _ FileStream newFileNamed: nameToUse.
		file header; timeStamp.
		self fileOutPreambleOn: file.
		self fileOutOn: file.
		self fileOutPostscriptOn: file.
		file trailer; close].

	Preferences suppressCheckForSlips ifTrue: [^ self].

	slips _ self checkForSlips.
	(slips size > 0 and: [self confirm: 'Methods in this fileOut have halts
or references to the Transcript
or other ''slips'' in them.
Would you like to browse them?'])
		ifTrue: [Smalltalk browseMessageList: slips
							name: 'Possible slips in ', name]