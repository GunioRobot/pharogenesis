spawnProtocol
        "Request that the receiver's model open a protocol browser."

        self controlTerminate.
        model spawnProtocol.
        self controlInitialize