timeSinceLastPassAsString: aResult
        (lastPass isNil or: [aResult hasPassed not]) ifTrue: [^ ''].
        ^ ', ' , (self formatTime: (Time now subtractTime: lastPass)) , '
since last Pass'