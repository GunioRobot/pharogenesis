newURLAndPageFor: aMorph
	"Create a new SqueakPage whose contents is the given morph. Assign a URL for that page, record it in the page cache, and answer its URL."

	| pg newURL stamp |
	pg _ self new.
	stamp _ Utilities authorInitialsPerSe ifNil: ['*'].
	pg saveMorph: aMorph author: stamp.
	newURL _ SqueakPageCache generateURL.
	SqueakPageCache atURL: newURL put: pg.
	^ newURL 
