testMonthPrintOn
    	| aMonth cs rw |
	aMonth _ Month starting: DateAndTime new duration: 31 days.  
	cs _ ReadStream on: 'January 1901'.
	rw _ ReadWriteStream on: ''.
     aMonth printOn: rw.
     self assert: rw contents = cs contents.