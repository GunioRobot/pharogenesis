knownName
	"If a formal name has been handed out for this object, answer it, else nil"
	
	^ References keyAtValue: self ifAbsent: [nil]