initialize
	"Initialize the receiver (automatically called when instances are created via 'new')"

	super initialize.
	self vocabularyName: #ButtonPhase.
	symbols _ #(buttonDown whilePressed buttonUp)