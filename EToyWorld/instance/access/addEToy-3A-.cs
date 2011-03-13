addEToy: anEToyHolder
	"Remember this guy, so we can show him again"

	etoys ifNil: [etoys _ OrderedCollection new].
	(etoys includes: anEToyHolder) ifFalse: [etoys addLast: anEToyHolder]