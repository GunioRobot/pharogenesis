isPublished
	"Answer if I have public releases."

	^releases anySatisfy: [:rel | rel isPublished]