fetchContentsIfAbsent: failBlock
	"Make every effort to get contentsMorph.  Assume I am in the cache already."
	| strm page temp temp2 |
	SqueakPageCache write.		"sorry about the pause"
	Cursor wait showWhile: [
		strm _ (ServerFile new fullPath: url) asStream].
	strm class == String ifTrue: [^ failBlock value].		
	page _ strm fileInObjectAndCode.
	page isMorph ifTrue: [contentsMorph _ page].	"may be a bare morph"
	"copy over the state"
	temp _ url.
	temp2 _ policy.
	self copyAddedStateFrom: page.
	url _ temp.	"don't care what it says"
	temp2 ifNotNil: [policy _ temp2].		"use mine"
	contentsMorph setProperty: #pageDirty toValue: nil.
	self dirty: false.
	^ contentsMorph