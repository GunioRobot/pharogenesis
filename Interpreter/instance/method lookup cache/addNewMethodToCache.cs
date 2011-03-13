addNewMethodToCache
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
	| probe hash |
	self inline: false.
	self compilerTranslateMethodHook.	"newMethod x lkupClass -> newNativeMethod (may cause GC !)"
	hash _ messageSelector bitXor: lkupClass.  "drop low-order zeros from addresses"

	0 to: CacheProbeMax-1 do:
		[:p | probe _ (hash >> p) bitAnd: MethodCacheMask.
		(methodCache at: probe + MethodCacheSelector) = 0 ifTrue:
				["Found an empty entry -- use it"
				methodCache at: probe + MethodCacheSelector put: messageSelector.
				methodCache at: probe + MethodCacheClass put: lkupClass.
				methodCache at: probe + MethodCacheMethod put: newMethod.
				methodCache at: probe + MethodCachePrim put: primitiveIndex.
				methodCache at: probe + MethodCacheNative put: newNativeMethod.
				^ nil]].

	"OK, we failed to find an entry -- install at the first slot..."
	probe _ hash bitAnd: MethodCacheMask.  "first probe"
	methodCache at: probe + MethodCacheSelector put: messageSelector.
	methodCache at: probe + MethodCacheClass put: lkupClass.
	methodCache at: probe + MethodCacheMethod put: newMethod.
	methodCache at: probe + MethodCachePrim put: primitiveIndex.
	methodCache at: probe + MethodCacheNative put: newNativeMethod.

	"...and zap the following entries"
	1 to: CacheProbeMax-1 do:
		[:p | probe _ (hash >> p) bitAnd: MethodCacheMask.
		methodCache at: probe + MethodCacheSelector put: 0].
