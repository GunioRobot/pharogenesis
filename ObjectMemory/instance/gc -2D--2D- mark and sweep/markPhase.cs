markPhase
	"Mark phase of the mark and sweep garbage collector. Set the mark bits of all reachable objects. Free chunks are untouched by this process."
	"Assume: All non-free objects are initially unmarked. Root objects were unmarked when they were made roots. (Make sure this stays true!!)."

	| oop |
	self inline: false.
	"clear the recycled context lists"
	freeContexts _ NilContext.
	freeLargeContexts _ NilContext.

	"trace the interpreter's objects, including the active stack and special objects array"
	self markAndTraceInterpreterOops.

	"trace the roots"
	1 to: rootTableCount do: [ :i | 
		oop _ rootTable at: i.
		self markAndTrace: oop.
	].
