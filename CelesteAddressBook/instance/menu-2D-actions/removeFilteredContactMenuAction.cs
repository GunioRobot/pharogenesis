removeFilteredContactMenuAction
	| list ret |
	list _ self contactList.
	ret _ PopUpMenu
				confirm: ('Are you sure to remove all\ the  ' , list size asString , ' contacts displayed?') withCRs
				trueChoice: 'yes, zap them from the contact list!'
				falseChoice: 'no, I was just joking...'.
	ret
		ifTrue: [
				Cursor wait showWhile: [list
						do: [:e | contactList removeKey: e]].
				self changed: #contactList]