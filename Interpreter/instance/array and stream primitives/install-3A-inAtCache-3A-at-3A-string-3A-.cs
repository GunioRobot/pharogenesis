install: rcvr inAtCache: cache at: atIx string: stringy
	"Install the oop of this object in the given cache (at or atPut), along with
	its size, format and fixedSize"
	| hdr fmt totalLength fixedFields |
	self var: #cache declareC: 'int *cache'.

	hdr _ self baseHeader: rcvr.
	fmt _ (hdr >> 8) bitAnd: 16rF.
	(fmt = 3 and: [self isContextHeader: hdr]) ifTrue:
		["Contexts must not be put in the atCache, since their size is not constant"
		^ self primitiveFail].
	totalLength _ self lengthOf: rcvr baseHeader: hdr format: fmt.
	fixedFields _ self fixedFieldsOf: rcvr format: fmt length: totalLength.

	cache at: atIx+AtCacheOop put: rcvr.
	stringy ifTrue: [cache at: atIx+AtCacheFmt put: fmt + 16]  "special flag for strings"
			ifFalse: [cache at: atIx+AtCacheFmt put: fmt].
	cache at: atIx+AtCacheFixedFields put: fixedFields.
	cache at: atIx+AtCacheSize put: totalLength - fixedFields.
