debugErrorTest: anInteger
        selectedErrorTest _ anInteger.  "added rew"
        selectedFailureTest _ 0.                        "added rew"
        self changed: #selectedFailureTest.             "added rew"
        self changed: #selectedErrorTest.               "added rew"
        (anInteger ~= 0)
                ifTrue: [(result errors at: anInteger) debug]