stuff
"
TileMorph readInArrowGraphics

Morph new beep
Smalltalk beep
1 to: 10 do:
	[:i | (SampledSound fromAIFFfileNamed: (i printString, '.aif')) play.
		Sensor waitButton.
		Sensor waitNoButton].

SampledSound soundNames ('peaks' 'warble' 'croak' 'scrape' 'camera' 'splash' 'coyote' 'scratch' 'coffeeCupClink' 'scritch' 'chirp' )

SampledSound soundNames do:
	[:n | SampledSound playSoundNamed: n.
		Sensor waitButton; waitNoButton].

Smalltalk at: #AA put:  (Form fromDisplay: (Point fromUser extent: 30@30)).
AA display
EToySystem formDictionary at: 'HalosOn' put: AA

Smalltalk at: #Temp put: (EToySystem formDictionary at: 'BalloonsOff')
EToySystem formDictionary at: 'KidsModeOff' put: (EToySystem formDictionary at: 'KidsOff')

"