storeID: id  username: theUsername password: thePassword privs: thePrivs text: text from: peer
	| page |
	page _ self atID: id.
	page date: (Date today).
	page text: text.
	page address: peer.
	(theUsername size > 1) ifTrue: [
		page username: theUsername.
		page password: thePassword.
		page privs: thePrivs.
		"Set up the authorization"
		action auth mapName: theUsername password: thePassword
			to: id.].
	^ page