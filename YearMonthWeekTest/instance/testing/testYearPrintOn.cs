testYearPrintOn
    	| aYear cs rw |
	aYear _ Year starting: DateAndTime new duration: 365 days. 
	cs _ ReadStream on: 'a Year (1901)'.
	rw _ ReadWriteStream on: ''.
     aYear printOn: rw.
     self assert: rw contents = cs contents.