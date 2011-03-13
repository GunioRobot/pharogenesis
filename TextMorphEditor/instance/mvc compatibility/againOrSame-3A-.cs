againOrSame: bool

	| bk keys |
	(bk _ morph ownerThatIsA: BookMorph) ifNotNil: [
		(keys _ bk valueOfProperty: #searchKey ifAbsent: [nil]) ifNotNil: [
			keys size > 0 ifTrue: [bk findText: keys]]].

	super againOrSame: bool.
	(morph respondsTo: #editView) ifTrue: [
		morph editView selectionInterval: self selectionInterval].