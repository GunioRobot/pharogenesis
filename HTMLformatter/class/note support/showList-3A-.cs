showList: aCollection
	"Return an HTML list to reference an ordered collection of notes. 
	prefix.index will be the reference URL for the note. Used in Comment 
	application. "
	| ret aNote |
	ret _ WriteStream on: String new.
	ret nextPutAll: '<ul>';
	 cr.
	1 to: aCollection size do: 
		[:each | 
		ret nextPutAll: '<li>'.
		aNote _ aCollection at: each.
		ret nextPutAll: (self linkTo: (aNote url) label: aNote title).
		ret nextPutAll: ' ' , aNote author , ' ' , aNote timestamp;
		 cr.
		aNote children size > 0 ifTrue: [ret nextPutAll: (self showList: aNote children)]].
	ret nextPutAll: '</ul>'.
	^ ret contents