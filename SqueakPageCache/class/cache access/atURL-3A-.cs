atURL: aURLString
	"Answer the page corresponding to this URL. Evaluate the given block if there is no entry for the given URL."

	| pg |
	^ PageCache at: aURLString ifAbsent: [
		pg _ SqueakPage new.
		"stamp _ Utilities authorInitialsPerSe ifNil: ['*']."
		"pg author: stamp."
		"Need to deal with inst vars if we turn out to be new!"
		"pg url: aURLString. 	done by atURL:put:"
		self atURL: aURLString put: pg.
		pg]
