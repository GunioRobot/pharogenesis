saveMorph: aMorph author: authorString
	"Save the given morph as this page's contents. Update its thumbnail and inform references to this URL that the page has changed."
	"Details: updateThumbnail releases the cached state of the saved page contents after computing the thumbnail."

	| n |
	contentsMorph _ aMorph.
	n _ aMorph knownName.
	n ifNotNil: [self title: n].
	creationAuthor ifNil: [
		creationAuthor _ authorString.
		creationTime _ Time totalSeconds].
"	lastChangeAuthor _ authorString.
	lastChangeTime _ Time totalSeconds.	do it when actually write"
	self computeThumbnail.
	self postChangeNotification.
