xxxFetch
	"Bring in my object and replace all references to me with references to him.  First try looking up my url in the pageCache.  Then try the page (and install it, under its url).  Then start from scratch with the url."

	| truePage object existing |
	existing _ SqueakPageCache pageCache at: url ifAbsent: [nil].
	existing ifNotNil: [existing isContentsInMemory
		ifTrue: [page _ truePage _ existing]].	"This url already has an object in this image"
	truePage ifNil: [
		truePage _ SqueakPageCache atURL: url oldPage: page].
	object _ truePage isContentsInMemory 
		ifTrue: [truePage contentsMorph]
		ifFalse: [truePage fetchInformIfError].	"contents, not the page"
			"Later, collect pointers to object and fix them up.  Not scan memory"
	object ifNil: [^ 'Object could not be fetched.'].
	"recursionFlag _ false."  	"while I still have a pointer to myself"
	truePage contentsMorph: object.
	page _ truePage.
	self xxxFixup.
	^ object	"the final object!"
 