objectToStoreOnDataStream
    "A DiskProxy proxies for some object put on a DataStream. When
     loaded back, the DiskProxy internalizes (comeFullyUpOnReload)
     by turning into the original object (we hope).
     Trying to put a *DiskProxy* on a DataStream won’t work since the
     loaded result will internalize itself into something else.
     Hence sending objectToStoreOnDataStream to a DataStream is
     a bug (or else a request to built a ‘quoter’ that will turn
     itself back into this DiskProxy object…)."

    self halt: 'redundant objectToStoreOnDataStream message'