mailOut
	"File out the receiver, to a file whose name is a function of the           
	change-set name and either of the date & time or chosen to have a
	unique numeric tag, depending on the preference
	'sequentialChangeSetRevertableFileNames'."

	| subjectPrefix slips messageStrm message compressBuffer compressStream data compressedStream compressTarget |
	(Smalltalk includesKey: #Celeste)
		ifFalse: [^ self notify: 'no mail reader present'].

	subjectPrefix _ self chooseSubjectPrefixForEmail.

	self checkForConversionMethods.
	Cursor write
		showWhile: 
			["Prepare the message"
			messageStrm _ WriteStream on: (String new: 30).
			messageStrm nextPutAll: 'From: ';
			 nextPutAll: Celeste userName;
			 cr;
			 nextPutAll: 'To: squeak@cs.uiuc.edu';
			 cr;
			 nextPutAll: 'Subject: ';
			 nextPutAll: subjectPrefix;
			 nextPutAll: name;
			 cr;
			 nextPutAll: 'from preamble:';
			 cr;
			 cr.
			self fileOutPreambleOn: messageStrm.
			"Prepare the gzipped data"
			message _ MailMessage from: messageStrm contents.
			message _ MailMessage from: message asMultipartText.
			data _ WriteStream on: String new.
			data header.
			self fileOutPreambleOn: data.
			self fileOutOn: data.
			self fileOutPostscriptOn: data.
			data trailer.
			data _ ReadStream on: data contents.
			compressBuffer _ ByteArray new: 1000.
			compressStream _ GZipWriteStream on: (compressTarget _ WriteStream on: (ByteArray new: 1000)).
			[data atEnd]
				whileFalse: [compressStream nextPutAll: (data nextInto: compressBuffer)].
			compressStream close.
			compressedStream _ ReadStream on: compressTarget contents asString.
			CelesteComposition
				openForCeleste: Celeste current 
				initialText: (message asTextEncodingNewPart: compressedStream named: name , '.cs.gz')].
	Preferences suppressCheckForSlips ifTrue: [^ self].
	slips _ self checkForSlips.
	(slips size > 0 and: [self confirm: 'Methods in this fileOut have halts
or references to the Transcript
or other ''slips'' in them.
Would you like to browse them?'])
		ifTrue: [Smalltalk browseMessageList: slips name: 'Possible slips in ' , name]