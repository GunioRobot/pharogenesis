findEmailsProcess
	"Process emails trying to find them.  
	Bug: the cc and to fields are hard to decode because them can contain 
	more  
	than an item. For the meantime, the result is quite good but more post  
	processing is needed here and in the pvtStore"
	| list m cBefore stats |
	self alert: ' Processing...'.
	self mailDB openDB.
	Cursor execute showWhile: [stats _ self mailDB compact].
	Transcript show:
		'Recovered ',
		(stats at: 1) printString, ' message',
		(((stats at: 1) = 1) ifTrue: [', '] ifFalse: ['s, ']),
		(stats at: 2) printString, ' bytes.  ',
		(stats at: 3) printString, ' active messages remain.'; cr.
	
	Cursor wait
		showWhile: [cBefore _ contactList size.
			list _ self mailDB messagesIn: '.all.'].
	Cursor execute
		showWhile: [list
				do: [:l | 
					m _ self mailDB getMessage: l.
					"Example of form output:"
					"Chiara Stoppa"
					"<c.stoppa@sol-tec.it>"
					self pvtStore: m from asString;
						 pvtStore: m to asString;
						 pvtStore: m cc asString.]].
	self changed: #contactList.
	self alert: 'Contacts:' , contactList size asString , ' New contacts Found: ' , (contactList size - cBefore) asString.