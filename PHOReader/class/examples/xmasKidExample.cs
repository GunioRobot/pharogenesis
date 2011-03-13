xmasKidExample
	| events |
	events := self xmasExample.
	events do: [ :each | each pitchBy: 1.6].
	^ events