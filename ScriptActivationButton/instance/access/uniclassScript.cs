uniclassScript
	"Answer the receiver's uniclassScript.  For old buttons, this might initially be nil but will get set, when possible herein."

	^ uniclassScript ifNil:
		[uniclassScript _ target class scripts at: arguments first ifAbsent: [nil]]