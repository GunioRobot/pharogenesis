spawnProtocol
        "Create and schedule a new protocol browser on the currently selected class or meta."
        classListIndex = 0 ifTrue: [^ self].
        ProtocolBrowser openSubProtocolForClass: self selectedClassOrMetaClass  