forgetURLs
	"About to save these objects in a new place.  Forget where stored now.  Must bring in all pages we don't have."

| pg |
pages do: [:aPage |
	aPage yourself.	"bring it into memory"
	(pg _ aPage valueOfProperty: #SqueakPage) ifNotNil: [
		SqueakPageCache removeURL: pg url.
		pg contentsMorph setProperty: #SqueakPage toValue: nil]].
self setProperty: #url toValue: nil.