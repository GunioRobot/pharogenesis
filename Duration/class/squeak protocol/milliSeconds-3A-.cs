milliSeconds: milliCount


	^ self days: 0 hours: 0 minutes: 0 seconds: 0 nanoSeconds: 
			(milliCount * (10 raisedToInteger: 6))
