pushExampleFemale
	| events |
	events _ self pushExample.
	events do: [ :each | each pitchBy: 1.93489].
	^ events