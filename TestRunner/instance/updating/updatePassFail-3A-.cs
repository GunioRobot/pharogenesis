updatePassFail: aTestResult
        | message |
        message _ aTestResult hasPassed
                                ifTrue: ['Pass']
                                ifFalse: ['Fail'].
        self displayPassFail: message