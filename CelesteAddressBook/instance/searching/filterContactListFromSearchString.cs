filterContactListFromSearchString
	|r s perc |
	searchString  = '' ifTrue:[ 
			self alert: 'Full listing (no filter applied)  ', 
				(contactList size) asString, ' contacts'.
			 ^ contactList].

	r _ Dictionary new.
	s _ '*', searchString , '*'.
	contactList keysAndValuesDo:[:k :v|
		(s match: k) ifTrue:[ r at: k put: v ].
	].

	[perc _ ( ( (r size) / (contactList size) * 100 ) roundTo: 0.01) asString. ]
      on:ZeroDivide do:[:ex| perc _' ?? '].

	self alert: 'Found ', (r size asString) , ' contacts [', perc , '% ]'.
	^r.
	