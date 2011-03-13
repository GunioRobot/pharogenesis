beginReference: anObject
    "Remember anObject as the object we read at the position recorded by
     noteCurrentReference:. This must be done after instantiating anObject but
     before reading any of its contents that might (directly or indirectly) refer to
     it. (It’s ok to do this redundantly, which is convenient for #next.)
     Answer the reference position. -- jhm"

    objects at: currentReference put: anObject.
    ^ currentReference