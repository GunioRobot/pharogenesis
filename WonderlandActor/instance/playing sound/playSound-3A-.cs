playSound: soundFile
	"Create an animation that plays the sound and lasts the duration of the sound"

	| aSound extension |

	extension _ (soundFile findTokens: '.') last.

	(extension = 'wav')
		ifTrue: [ [ aSound _ SampledSound fromWaveFileNamed: soundFile ]
					ifError: [ :msg : rcvr | myWonderland reportErrorToUser:
										(soundFile asString) , ' is not a valid sound.'.
											^ nil ]
				]
		ifFalse: [ aSound _ SampledSound soundNamed: soundFile.
				  aSound ifNil: [ ^ nil ] ].

	^ myWonderland doTogether: {
				self do: [ aSound play ].
				self wait: (aSound duration)
								}.
