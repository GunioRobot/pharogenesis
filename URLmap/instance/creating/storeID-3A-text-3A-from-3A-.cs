storeID: id text: text from: peer
	| page |
	page _ self atID: id.
	page date: (Date today).
	page time: (Time now).
	page text: text.
	page address: peer.
	^ page