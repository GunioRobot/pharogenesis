updateWindow: aTestResult
        aTestResult errors size + aTestResult failures size = 0
                ifTrue: [self updatePartColors: self passColor]
                ifFalse: [aTestResult errors size > 0
                                ifTrue: [self updatePartColors: self
errorColor]
                                ifFalse: [self updatePartColors: self
failColor]].
        self updatePassFail: aTestResult.
        self updateDetails: aTestResult.
        self updateFailures: aTestResult.
        self updateErrors: aTestResult