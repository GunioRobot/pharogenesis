setUp
	super setUp.
	"disable external calls"
	(self class selectors
		select: [:sel | sel beginsWith: 'lDisabled'])
		do: [:sel | (self class >> sel) literals first at: 4 put: -2]