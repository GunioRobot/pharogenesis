testPrintOn
    	|cs rw |
	cs _ ReadStream on: '1:02:03:04.000000005'.
	rw _ ReadWriteStream on: ''.
     aDuration printOn: rw.
     self assert: rw contents = cs contents.