storeID: id text: insertedText insertAt: idString
	"Insert in a place in the text.  Just before '*append here 34*' if
idString is '34'."
	| page bigText ind toInsert |
	page _ self atID: id.
	page date: (Date today).
	bigText _ page text.
	ind _ bigText findString: '*append here ',idString,'*' startingAt:
1.	"always lower case"
	ind = 0 ifTrue: [^ page].		"could not find that place"
	"Make sure new text surrounded by line feeds"
	toInsert _ (insertedText last == Character linefeed)
		ifTrue: [insertedText]
		ifFalse: [insertedText, (String with: Character linefeed)].
	((insertedText first == Character linefeed) or: [
		(bigText at: (ind-1 max: 1)) == Character linefeed])
			ifFalse: [toInsert _ (String with: Character
linefeed), toInsert].
	page text: (bigText copyReplaceFrom: ind to: ind-1 with: toInsert).
	"page address: peer.  Don't sign with person who only added"
	^ page