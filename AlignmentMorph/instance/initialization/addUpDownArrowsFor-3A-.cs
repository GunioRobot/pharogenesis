addUpDownArrowsFor: aMorph
	"Add a column of up and down arrows that serve to send upArrowHit and downArrowHit to aMorph when they're pressed/held down"

	| holder downArrow upArrow |
	holder _ Morph new extent: 16 @ 16; beTransparent.
	downArrow _ ImageMorph new image: (ScriptingSystem formAtKey: 'DownArrow').
	upArrow _ ImageMorph new image: (ScriptingSystem formAtKey: 'UpArrow').
	upArrow position: holder bounds topLeft + (2@2).
	downArrow align: downArrow bottomLeft
				with: holder topLeft + (0 @ TileMorph defaultH) + (2@-2).
	holder addMorph: upArrow.
	holder addMorph: downArrow.
	self addMorphBack: holder.
	upArrow on: #mouseStillDown send: #upArrowHit to: aMorph.
	downArrow on: #mouseStillDown send: #downArrowHit to: aMorph.