sendBugReportEmail
	|msg|
	msg _ MailMessage empty.
	msg setField: 'subject' toString: '[CAB] [BUGREPORT]'.
	msg setField: 'to' toString: ' "Giovanni Giorgi" <jj@objectsroot.com> '.
	msg setField: 'from' toString: (Celeste  userName asString).
	CelesteComposition
				openForCeleste: Celeste current 
				initialText: msg text.