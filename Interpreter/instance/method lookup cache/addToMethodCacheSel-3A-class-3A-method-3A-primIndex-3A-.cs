addToMethodCacheSel: selector class: class method: meth primIndex: primIndex
	"Add the given entry to the method cache.
	The policy is as follows:
		Look for an empty entry anywhere in the reprobe chain.
		If found, install the new entry there.
		If not found, then install the new entry at the first probe position
			and delete the entries in the rest of the reprobe chain.
		This has two useful purposes:
			If there is active contention over the first slot, the second
				or third will likely be free for reentry after ejection.
			Also, flushing is good when reprobe chains are getting full."
	"ar 3/10/2000: Store class in lkupClass so that a primitive response 
	can rewrite the mcache entry. Currently this is only used by
	primitiveExternalCall (see comment there) to allow fast failure for 
	any external primitive that is not found."
	| probe hash |
	self inline: false.
	lkupClass _ class.
	hash _ selector bitXor: class.  "drop low-order zeros from addresses"

	0 to: CacheProbeMax-1 do:
		[:p | probe _ (hash >> p) bitAnd: MethodCacheMask.
		(methodCache at: probe + MethodCacheSelector) = 0 ifTrue:
				["Found an empty entry -- use it"
				methodCache at: probe + MethodCacheSelector put: selector.
				methodCache at: probe + MethodCacheClass put: class.
				methodCache at: probe + MethodCacheMethod put: meth.
				methodCache at: probe + MethodCachePrim put: primIndex.
				^ nil]].

	"OK, we failed to find an entry -- install at the first slot..."
	probe _ hash bitAnd: MethodCacheMask.  "first probe"
	methodCache at: probe + MethodCacheSelector put: selector.
	methodCache at: probe + MethodCacheClass put: class.
	methodCache at: probe + MethodCacheMethod put: meth.
	methodCache at: probe + MethodCachePrim put: primIndex.

	"...and zap the following entries"
	1 to: CacheProbeMax-1 do:
		[:p | probe _ (hash >> p) bitAnd: MethodCacheMask.
		methodCache at: probe + MethodCacheSelector put: 0].
