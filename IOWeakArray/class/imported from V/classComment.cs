classComment
"An IOWeakArray is like an Array except that it acts like a weak object (holds weak
pointers) on a ReferenceStream.

In an objectToStoreOnDataStream (externalize) method, putting some objects into an
IOWeakArray is a practical way to write them via ReferenceStream>>nextPutWeak:.
    -- 11/15/92 jhm
"