informUserDuring: aBlock
	"Display a message above (or below if insufficient room) the cursor during execution of the given block."
	"Utilities informUserDuring:[:bar|
		#(one two three) do:[:info|
			bar value: info.
			(Delay forSeconds: 1) wait]]"
	Smalltalk isMorphic
		ifTrue:
			[(MVCMenuMorph from: (SelectionMenu labels: '') title: '						')
				informUserAt: Sensor cursorPoint during: aBlock.
			^ self].
	aBlock value:[:string| Transcript cr; show: string]