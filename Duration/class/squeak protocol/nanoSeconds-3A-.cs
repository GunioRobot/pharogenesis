nanoSeconds: nanos

	^ self new
		seconds: (nanos quo: NanosInSecond) 
		nanoSeconds: (nanos rem: NanosInSecond) rounded;
		yourself.
