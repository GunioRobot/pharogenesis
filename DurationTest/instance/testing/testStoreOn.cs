testStoreOn
     self assert: (aDuration storeOn: (WriteStream on:'')) asString ='1:02:03:04.000000005'. 
     "storeOn: returns a duration (self) not a stream"