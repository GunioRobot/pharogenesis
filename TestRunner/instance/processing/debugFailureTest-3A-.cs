debugFailureTest: anInteger

        (anInteger ~= 0)
                ifTrue: [(self failures at: anInteger) debugAsFailure].

        selectedFailureTest _ anInteger.
        selectedErrorTest _ 0.
        self changed: #selectedErrorTest.
        self changed: #selectedFailureTest.
