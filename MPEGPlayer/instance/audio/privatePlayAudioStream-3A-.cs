privatePlayAudioStream: aStream
	| number |

	number _ 5.
	self soundQueue: (QueueSound new startTime: 0).
	[number + 2 timesRepeat: [self soundQueue add: (self createSoundFrom: aStream)].
	self soundQueue play.
	semaphoreForSound signal.
	[[self soundQueue sounds size > number] whileTrue: [(Delay forMilliseconds: 100) wait].
	self soundQueue add: (self createSoundFrom: aStream).
	(self endOfAudio: aStream) 
		ifTrue: 
			[self audioPlayerProcess: nil.
			^self]] repeat] on: Error do: 
				[self audioPlayerProcess: nil.
				^self]