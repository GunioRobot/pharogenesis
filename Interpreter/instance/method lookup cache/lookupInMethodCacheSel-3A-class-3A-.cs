lookupInMethodCacheSel: selector class: class
	"This method implements a simple method lookup cache. If an entry for the given selector and class is found in the cache, set the values of 'newMethod' and 'primitiveIndex' and return true. Otherwise, return false."
	"About the re-probe scheme: The hash is the low bits of the XOR of two large addresses, minus their useless lowest two bits. If a probe doesn't get a hit, the hash is shifted right one bit to compute the next probe, introducing a new randomish bit. The cache is probed CacheProbeMax times before giving up."
	"WARNING: Since the hash computation is based on the object addresses of the class and selector, we must rehash or flush when compacting storage. We've chosen to flush, since that also saves the trouble of updating the addresses of the objects in the cache."

	| hash probe |
	self inline: true.
	hash _ selector bitXor: class.  "shift drops two low-order zeros from addresses"

	probe _ hash bitAnd: MethodCacheMask.  "first probe"
	(((methodCache at: probe + MethodCacheSelector) = selector) and:
		 [(methodCache at: probe + MethodCacheClass) = class]) ifTrue:
			[newMethod _ methodCache at: probe + MethodCacheMethod.
			primitiveIndex _ methodCache at: probe + MethodCachePrim.
			newNativeMethod _ methodCache at: probe + MethodCacheNative.
			primitiveFunctionPointer _ methodCache at: probe + MethodCachePrimFunction.
			^ true	"found entry in cache; done"].

	probe _ (hash >> 1) bitAnd: MethodCacheMask.  "second probe"
	(((methodCache at: probe + MethodCacheSelector) = selector) and:
		 [(methodCache at: probe + MethodCacheClass) = class]) ifTrue:
			[newMethod _ methodCache at: probe + MethodCacheMethod.
			primitiveIndex _ methodCache at: probe + MethodCachePrim.
			newNativeMethod _ methodCache at: probe + MethodCacheNative.
			primitiveFunctionPointer _ methodCache at: probe + MethodCachePrimFunction.
			^ true	"found entry in cache; done"].

	probe _ (hash >> 2) bitAnd: MethodCacheMask.
	(((methodCache at: probe + MethodCacheSelector) = selector) and:
		 [(methodCache at: probe + MethodCacheClass) = class]) ifTrue:
			[newMethod _ methodCache at: probe + MethodCacheMethod.
			primitiveIndex _ methodCache at: probe + MethodCachePrim.
			newNativeMethod _ methodCache at: probe + MethodCacheNative.
			primitiveFunctionPointer _ methodCache at: probe + MethodCachePrimFunction.
			^ true	"found entry in cache; done"].

	^ false
