silent
	"Can installations ask questions or should they be silent
	and us good defaults?"

	^ silent ifNil: [false] ifNotNil: [true]