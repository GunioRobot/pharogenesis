openThreadNamed: nameOfThread atIndex: anInteger

	| coll nav |

	coll _ self knownThreads at: nameOfThread ifAbsent: [^self].
	nav _ World 
		submorphThat: [ :each | (each isKindOf: self) and: [each threadName = nameOfThread]]
		ifNone: [
			nav _ self basicNew.
			nav
				listOfPages: coll;
				threadName: nameOfThread index: anInteger;
				initialize;
				openInWorld;
				positionAppropriately.
			^self
		].
	nav
		listOfPages: coll;
		threadName: nameOfThread index: anInteger;
		removeAllMorphs;
		addButtons.

