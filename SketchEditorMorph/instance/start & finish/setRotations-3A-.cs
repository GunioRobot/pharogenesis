setRotations: num
	"Tell the palette what number of rotations (or background) to show.  "

	| key |
	key _ 'ItTurns'.	"default and value for num > 1"
	num == 1 ifTrue: [key _ 'JustAsIs'].
	num == 18 ifTrue: [key _ 'ItTurns'].
	num == 99 ifTrue: [key _ 'ToAndFro'].
	num == #Background ifTrue: [key _ 'Background'].
	num == #Repeated ifTrue: [key _ 'Repeated'].
	palette setRotations: (palette contentsAtKey: key).