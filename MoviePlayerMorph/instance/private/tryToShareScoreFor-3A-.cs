tryToShareScoreFor: fileName

	scorePlayer _ nil.
	self class allInstancesDo:
		[:mp | mp == self ifFalse:
			[mp soundTrackFileName = fileName ifTrue:
				["Found this score already open in another player
					-- return a copy that shares the same sound buffer."
				mp scorePlayer ifNotNil: [^ scorePlayer _ mp scorePlayer copy reset]]]]