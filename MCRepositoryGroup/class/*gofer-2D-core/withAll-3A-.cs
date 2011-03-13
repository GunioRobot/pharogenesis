withAll: anArray
	^ anArray
		inject: self new
		into: [ :group :repo | group addRepository: repo ]