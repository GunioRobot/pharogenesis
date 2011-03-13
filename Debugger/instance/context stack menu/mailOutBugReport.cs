mailOutBugReport
	"Compose a useful bug report showing the state of the process as well as vital image statistics as suggested by Chris Norton - 
'Squeak could pre-fill the bug form with lots of vital, but
oft-repeated, information like what is the image version, last update
number, VM version, platform, available RAM, author...'

and address it to the list with the appropriate subject prefix."

	| subjectPrefix messageStrm |
	(Smalltalk includesKey: #Celeste)
		ifFalse: [^ self notify: 'no mail reader present'].

	subjectPrefix _ '[BUG]'.

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
			 nextPutAll: self interruptedContext printString;
			 cr;cr;
			 nextPutAll: 'here insert explanation of what you were doing, suspect changes youd made and so forth.';cr;cr;
			 nextPutAll: 'Image version: ';
			 nextPutAll: Smalltalk systemInformationString ; cr;cr;
			 nextPutAll: 'VM version: ';
			 nextPutAll: Smalltalk vmVersion, String cr, 'for: ', Smalltalk platformName ; cr;cr;
			 nextPutAll: 'Receiver: ';
			 nextPutAll: receiverInspector object printString; cr;cr;
			 nextPutAll: 'Instance variables: ';cr;
			 nextPutAll: receiverInspector object longPrintString; cr;
			 nextPutAll: 'Method (temp) variables: ';cr;
			 nextPutAll: contextVariablesInspector object tempsAndValues; cr;
			 nextPutAll: 'Stack: '; cr.
			self contextStackList do: [:e | messageStrm nextPutAll: e; cr].

			CelesteComposition
				openForCeleste: Celeste current 
				initialText: messageStrm contents].
