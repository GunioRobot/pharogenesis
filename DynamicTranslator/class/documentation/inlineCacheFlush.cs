inlineCacheFlush
"
The inline caches must be flushed on every programming change.  This is more difficult than it may seem, since contexts that are already executing in some redefined method must continue to execute the stale version until the next time they are invoked.  At the same time, all further sends (whether they are linked or unlinked) must reach the redefined version of the method.

The translator performs this flushing by writing the current 'translation cycle' (an integer) into the header of every translated method.  When performing a linked send, the VM compares the translation cycle stored in the method header with the current translation cycle; if they differ then the cache 'misses' and the send is relinked.  To flush the inline cache it suffices to increment the current translation cycle.  This causes all linked send sites to 'miss' the next time that they execute.  (See DynamicTranslator>>flushInlineCache.)

The impact of this rather brutal flushing can be reduced (during a selective flush) by bringing any translated methods that are referenced from the method cache (*after* the affected selector has been flushed from the method cache) forward into the new translation cycle.  (See DynamicTranslator>>flushMethodCacheSelective:.)

Note that the above mechanism ensures that live Contexts will continue to execute in the stale translated version of a redefined method, as required.
"
	^self error: 'documentation only'