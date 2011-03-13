stopUp: dummy with: theButton
	associatedMorph world flushPlayerListCache.  "catch guys not in cache but who're running"
	self stopRunningScripts