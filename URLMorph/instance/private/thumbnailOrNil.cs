thumbnailOrNil
	"Answer the thumbnail Form for the page this morph represents. Answer nil if no thumbnail is available."

	| thum |
	page ifNil: [page _ SqueakPageCache atURL: url].
	(thum _ page thumbnail) ifNil: [^ nil].
	^ (thum isKindOf: Form) 
		ifTrue: [thum]
		ifFalse: [thum form]	"a BookPageThumbnailMorph"
