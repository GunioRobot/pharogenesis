flush
	"Play all the events in the queue."
	super flush.
	self do: [ :each | each flush]