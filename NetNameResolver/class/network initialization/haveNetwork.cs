haveNetwork
	"Our best estimate of whether a network is available.  Caller will want to ask user if we should try this time."

	HaveNetwork ifFalse: [^ false].
	Time totalSeconds - LastContact > 1800 "30 min" ifTrue: [^ #expired].
	^ true	"are current"