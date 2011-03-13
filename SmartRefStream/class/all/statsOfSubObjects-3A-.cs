statsOfSubObjects: anObject
	"Open a window with statistics on what objects would be written out with anObject.  Does not actually write on the disk.  Stats in the form:
	ScriptEditorMorph 51
		SortedCollection (21->LayoutMorph 15->SimpleButtonMorph 9->Array 4->CompoundTileMorph 2->StringMorph )"

	| dummy printOut |
	dummy _ ReferenceStream on: (DummyStream on: nil).
		"Write to a fake Stream, not a file"
	"Collect all objects"
	dummy rootObject: anObject.	"inform him about the root"
	dummy nextPut: anObject.
	"(dummy references) is the raw data"
	printOut _ dummy statisticsOfRefs.
	(StringHolder new contents: printOut) 
		openLabel: 'ReferenceStream statistics'.