fileOut
	"File out the receiver, to a file whose name is a function of the change-set name and of the date and the time."
	| file slips |
	Cursor write showWhile: [
		file _ FileStream newFileNamed:
			((self name, FileDirectory dot, Utilities dateTimeSuffix, FileDirectory dot, 'cs')
				truncateTo: 27).
		file header; timeStamp.
		self fileOutPreambleOn: file.
		self fileOutOn: file.
		self fileOutPostscriptOn: file.
		file trailer; close].

	Preferences suppressCheckForSlips ifTrue: [^ self].  "Can hard-code that pref if desired"

	slips _ self checkForSlips.
	(slips size > 0 and: [self confirm: 'Methods in this fileOut have halts
or references to the Transcript in them.
Would you like to browse them?'])
		ifTrue: [Smalltalk browseMessageList: slips
							name: 'References to #halt or Transcript']