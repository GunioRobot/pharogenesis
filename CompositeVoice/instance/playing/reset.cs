reset
	"Reset the state of the receiver."
	super reset.
	self do: [ :each | each reset]